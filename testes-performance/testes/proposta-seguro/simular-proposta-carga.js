import http from 'k6/http'
import { check, sleep } from 'k6'
import { dadosProposta } from '../dados-proposta.js'
import { htmlReport } from "https://raw.githubusercontent.com/benc-uk/k6-reporter/main/dist/bundle.js";
import { textSummary } from "https://jslib.k6.io/k6-summary/0.0.1/index.js";

export function handleSummary(data) {
  return {
    "simular_propostas_220_usuarios.html": htmlReport(data),
    stdout: textSummary(data, { indent: " ", enableColors: true }),
  };
}

export const options = {
    thresholds: {
        http_req_failed: ['rate < 0.00001'],
        http_req_duration: ['p(100)<=1000'],
    },
    scenarios: {
        simular_propostas_220_usuarios: {
            executor: 'constant-vus',
            vus: 220,
            duration: '5m',
        },
    },
}

export default function () {
    const url = `http://localhost:8080/seguro/propostas/simulacao`
                 
    const resposta = http.post(url, JSON.stringify(dadosProposta()), {
        headers: { 'Content-Type': 'application/json' },
    })

    check(resposta, {
        'Status 200': (res) => res.status === 200,
    })

    sleep(1)
}