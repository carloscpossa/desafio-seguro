import http from 'k6/http'
import { check, sleep } from 'k6'
import { dadosProposta } from './dados-proposta.js'


export const options = {
    vus: 3,
    iterations: 10    
}


export default function() {

    const url = `http://localhost:8080/seguro/proposta`    

    const resposta = http.post(url, JSON.stringify(dadosProposta()), {
        headers: { 'Content-Type': 'application/json' },
    })    

    check(resposta, {
        'Status 201': (res) => res.status === 201
    })

    sleep(1)
}