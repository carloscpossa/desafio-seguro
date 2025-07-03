import http from 'k6/http'
import { check, sleep } from 'k6'
import { dadosProposta } from '../dados-proposta.js'
import { htmlReport } from "https://raw.githubusercontent.com/benc-uk/k6-reporter/main/dist/bundle.js";

export function handleSummary(data) {
  return {
    "resultados-testes.html": htmlReport(data),
  };
}

export const options = {   
    thresholds: {
        http_req_failed: ['rate < 0.00001']
    },
    // scenarios: {
    //     emitir_10000_apolices_por_dia: {
    //         executor: 'constant-arrival-rate',
    //         rate: 10000,
    //         timeUnit: '1d',
    //         duration: '1m',
    //         preAllocatedVUs: 50,
    //         maxVUs: 200,
    //     },
    // },
    scenarios: {
        emitir_10000_apolices_por_dia: {
            executor: 'ramping-arrival-rate',
            startRate: 0,
            timeUnit: '1d',            
            preAllocatedVUs: 50,
            maxVUs: 200,
            stages: [
                { target: 10000, duration: '1m' },
                { target: 10000, duration: '6m' },
                { target: 0, duration: '1m' },
            ],
        },
    },
}

export default function () {
    const urlProposta = `http://localhost:8080/seguro/proposta`
    const respostaProposta = http.post(urlProposta, JSON.stringify(dadosProposta()), {
        headers: { 'Content-Type': 'application/json' },
    })

    check(respostaProposta, {
        'Status 201': (res) => res.status === 201,
    })

    const urlApolice = `http://localhost:8080/seguro/apolice`
    const respostaApolice = http.post(urlApolice, respostaProposta.body, {
        headers: { 'Content-Type': 'application/json' },
    })

    check(respostaApolice, {
        'Status 201': (res) => res.status === 201,
    })

    sleep(1)
}