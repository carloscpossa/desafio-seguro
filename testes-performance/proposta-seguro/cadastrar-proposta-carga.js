import http from 'k6/http'
import { check, sleep } from 'k6'
import { dadosProposta } from '../dados-proposta.js'

export const options = {    
    scenarios: {
        cadastrar_propostas_1000_por_minuto: {
            executor: 'constant-arrival-rate',
            rate: 1000,
            timeUnit: '1m',
            duration: '5m',
            preAllocatedVUs: 50,
            maxVUs: 200,
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