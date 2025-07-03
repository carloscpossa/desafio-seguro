import http from 'k6/http'
import { check, sleep } from 'k6'
import { dadosProposta } from '../dados-proposta.js'

export const options = {
    thresholds: {
        http_req_failed: ['rate < 0.00001']
    },
    scenarios: {
        cadastrar_propostas_1000_por_minuto: {
            executor: 'ramping-arrival-rate',
            startRate: 0,
            timeUnit: '1m',
            preAllocatedVUs: 50,
            maxVUs: 200,
            stages: [
                { target: 1000, duration: '30s' },
                { target: 1000, duration: '5m' },
                { target: 0, duration: '30s' },
            ],
        },
    },    
}

export default function () {
    const url = `http://localhost:8080/seguro/proposta`

    const resposta = http.post(url, JSON.stringify(dadosProposta()), {
        headers: { 'Content-Type': 'application/json' },
    })

    check(resposta, {
        'Status 201': (res) => res.status === 201,
    })

    sleep(1)
}