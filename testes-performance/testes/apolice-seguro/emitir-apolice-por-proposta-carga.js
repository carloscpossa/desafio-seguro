import http from 'k6/http'
import { check, sleep } from 'k6'
import { dadosProposta } from '../dados-proposta.js'
import { htmlReport } from "https://raw.githubusercontent.com/benc-uk/k6-reporter/main/dist/bundle.js";
import { textSummary } from "https://jslib.k6.io/k6-summary/0.0.1/index.js";

export function handleSummary(data) {
  return {
    "emitir_10000_apolices_por_proposta_por_dia.html": htmlReport(data),
    stdout: textSummary(data, { indent: " ", enableColors: true }),
  };
}

export const options = {   
    thresholds: {
        http_req_failed: ['rate < 0.00001'],
        http_req_duration: ['p(98)<=5000'],
    },    
    scenarios: {
        emitir_10000_apolices_por_proposta_por_dia: {
            executor: 'constant-arrival-rate',            
            duration: '5m',
            rate: 10000,
            timeUnit: '1d',
            preAllocatedVUs: 50,
            maxVUs: 200,            
        },
    },
}

export default function () {
    const urlProposta = `http://localhost:8080/seguro/proposta`
    const respostaProposta = http.post(urlProposta, JSON.stringify(dadosProposta()), {
        headers: { 'Content-Type': 'application/json' },
    })
    
    const urlApolice = `http://localhost:8080/seguro/apolice`
    const respostaApolice = http.post(urlApolice, respostaProposta.body, {
        headers: { 'Content-Type': 'application/json' },
    })

    check(respostaApolice, {
        'Status 201': (res) => res.status === 201,
    })    
}