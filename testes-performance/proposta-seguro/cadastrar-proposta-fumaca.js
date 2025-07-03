import http from 'k6/http'
import { check, sleep } from 'k6'

export const options = {
    vus: 1,
    iterations: 10
    //duration: '1m'
}


export default function() {

    const url = `http://localhost:8080/seguro/proposta`

    const dadosProposta = {
        veiculo: {
            placa: "SIV2A77",
            valorDeTabela: 10000,
            anoDeFabricacao: 2023
        },
        cliente: {
            nome: "Carlos Possa",
            dataNascimento: "1982-12-19"
        }
    }

    const resposta = http.post(url, JSON.stringify(dadosProposta), {
        headers: { 'Content-Type': 'application/json' },
    })
    

    sleep(1)

    check(resposta, {
        'Status 201': (res) => res.status === 201
    })
}