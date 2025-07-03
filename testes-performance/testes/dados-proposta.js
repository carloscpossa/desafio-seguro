import { faker } from 'https://cdn.jsdelivr.net/npm/@faker-js/faker/+esm';
//import { faker } from '@faker-js/faker'

export const dadosProposta = () => {

    return {
        veiculo: {
            placa: faker.vehicle.vrm(),
            valorDeTabela: faker.finance.amount({min: 1000, max: 10000000}),
            anoDeFabricacao: faker.number.int({min: 1950, max: 2025})
        },
        cliente: {
            nome: faker.person.fullName(),
            dataNascimento: `${faker.number.int({min: 1925, max: 2020})}-07-02`
        }
    }

    // return {
    //     veiculo: {
    //         placa: 'XPT1203',
    //         valorDeTabela: 50000,
    //         anoDeFabricacao: 2020
    //     },
    //     cliente: {
    //         nome: 'Cliente Teste',
    //         dataNascimento: '1982-12-19'
    //     }
    // }
}