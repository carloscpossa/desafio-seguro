# Desafio Seguro API

## Visão Geral

Este projeto consiste em uma aplicação (Web API) para criação de propostas de seguros automotivos e emissão de apólices.

---

## Informações sobre a aplicação desenvolvida:

- A aplicação foi desenvolvida em [ASP.NET Core 9](https://dotnet.microsoft.com/en-us/apps/aspnet)
- Como banco de dados, foi utilizado o [MongoDb](https://www.mongodb.com/)
- A aplicação (solution) é composta de dois projetos:
  - Um projeto com nome DesafioSeguro dentro da pasta `src` que é o projeto com o código de produção das Web APIs. Essas APIs foram desenvolvidas usando [minimal apis](https://learn.microsoft.com/en-us/aspnet/core/tutorials/min-web-api?view=aspnetcore-9.0&tabs=visual-studio)
  - Um projeto dentro da pasta `testes` com o nome DesafioSeguro.Unidade que é um projeto de testes de unidade utilizando xUnit e algumas bibliotecas como: Moq, AutoMocker, Bogus e AwesomeAssertions.
- Para visualizar a documentação da API (OpenAPI) e realizar interações manuais, foi utilizada a ferramenta [Scalar](https://scalar.com/)
- Todos os recursos necessários para execução da aplicação e das ferramentas utilizadas estão definidos no arquivo `docker-compose.yaml`.
- Para executar a aplicação, o modo mais fácil é através de containers rodando o comando `docker compose up -d` a partir do diretório raiz deste projeto.
- A aplicação está configurada para ser executada na porta 8080 (http://localhost:8080/scalar/v1).

## Testes de Performance

O diretório `testes-performance` contém scripts de teste de performance utilizando o [k6](https://k6.io/).

### Testes relevantes de acordo com os requisitos não funcionais que devem ser atendidos

- **cadastrar-proposta-carga.js**: Testa o endpoint de cadastro de propostas com 1000 requisições por minuto durante 5 minutos, validando que todas as respostas sejam 201.
- **simular-proposta-carga.js**: Testa o endpoint de simulação de propostas com um cenário de 220 usuários simultâneos durante 5 minutos.
- **emitir-apolice-por-proposta-carga.js**: Testa o endpoint de emissão de apólices com geração de 10.000 apólices por dia.

### Resultados dos Testes

- Os testes foram executados localmente em máquina de desenvolvimento.
- Os resultados dos testes estão dentro da pasta `resultados`. Há dentro desta pasta, para cada cenário relevante de teste, dois arquivos exibindo os resultados: uma página HTML e uma imagem com um resumo obtido do terminal do computador erm que os testes foram executados
- O computador no qual os testes foram executados possui sistema operacional Linux Mint, 16GB de RAM e processador Intel© Core™ i7-8565U CPU @ 1.80GHz × 4

- **IMPORTANTE**
  - O teste para simulação de propostas foi executado com 220 usuários simultâneos ao invés dos 300 usuários exigidos. Isso ocorreu em virtude da capacidade do hardware que o teste estava sendo executado, já que o processo do K6 era interrompido ainda quando estava provisionando os usuários virtuais (VUs) para executar os testes.


## Como Executar

### Aplicação WEB

1. Execute o comando abaixo no terminal:
   ```bash
   docker compose up -d
   ```

### Testes de Performance

1. Instale o [k6](https://grafana.com/docs/k6/latest/).
2. Exemplo para executar o teste de carga do cadastro de propostas
   ```bash
   k6 run ./testes-performance/testes/proposta-seguro/cadastrar-proposta-carga.js
   ``` 
3. Exemplo para executar o teste de carga da simulção de propostas
   ```bash
   k6 run ./testes-performance/testes/proposta-seguro/simular-proposta-carga.js
   ``` 
4. Exemplo para executar o teste de carga de emissão de apólices
   ```bash
   k6 run ./testes-performance/testes/apolice-seguro/emitir-apolice-por-proposta-carga.js
   ``` 