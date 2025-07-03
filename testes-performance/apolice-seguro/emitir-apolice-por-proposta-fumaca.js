import http from 'k6/http'
import { check, sleep } from 'k6'
import { dadosProposta } from '../dados-proposta.js'

export const options = {
    vus: 3,
    iterations: 10    
}

export default function() {

    const urlProposta = `http://localhost:8080/seguro/proposta`

    const respostaProposta = http.post(urlProposta, JSON.stringify(dadosProposta()), {
        headers: { 'Content-Type': 'application/json' },
    })            

    const urlApolice = `http://localhost:8080/seguro/apolice`
    const respostaApolice = http.post(urlApolice, respostaProposta.body, {
        headers: { 'Content-Type': 'application/json' },
    })

    check(respostaApolice, {
        'Status 201': (res) => res.status === 201
    })

    sleep(1)
}