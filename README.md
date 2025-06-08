# 🌧️ Projeto Social

---

## 👨‍💻 Integrantes

- Caroline Assis Silva - RM 557596  
- Enzo de Moura Silva - RM 556532  
- Luis Henrique Gomes Cardoso - RM 558883  

---

Este projeto tem como objetivo **ajudar famílias afetadas por desastres naturais**, principalmente **danos causados pela chuva no Brasil** e **necessidades enfrentadas no período de frio**.

A iniciativa busca mapear e prestar assistência a:
- Pessoas com deficiência
- Famílias com animais
- Famílias em situação de vulnerabilidade

Além disso, oferece um **formulário para cadastro de voluntários**, permitindo que mais pessoas contribuam com a nossa causa.

## 🛠️ Tecnologias Utilizadas

- ASP.NET Core
- Entity Framework Core
- Swagger 
- Razor Pages com TagHelpers
- SQL Server
- Git e GitHub para versionamento

## 📋 Funcionalidades

- 📄 Formulário para mapear pessoas necessitadas
- 🐶 Identificação de famílias com animais
- ♿ Inclusão de pessoas com deficiência
- 🧤 Ajuda emergencial em tempos de frio
- 🙋 Cadastro de voluntários

## 🚀 Como rodar o projeto localmente

1. **Clone o repositório**:

```bash
git clone https://github.com/codecrazes/GS.NET.git

cd GS.NET
```
2. **Restaure as dependências e atualize o banco**:
```bash
dotnet restore
dotnet ef database update
```
3. **Execute o projeto**:

```bash
dotnet run
```

Os comandos abaixo foram utilizados para testar os endpoints da API FormularioFamilia.
# 🔍 Listar todas as famílias
curl -X 'GET' 
  'http://localhost:8080/api/FormularioFamilia' 


# ➕ Cadastrar nova família
curl -X 'POST' \
  'http://localhost:8080/api/FormularioFamilia'

```json
{
  "fullName": "João da Silva",
  "cpf": "123.456.789-00",
  "phone": "(11)91234-5678",
  "address": {
    "street": "Rua Exemplo",
    "number": "123",
    "neighborhood": "Bairro Central",
    "city": "Cidade Exemplo",
    "state": "Estado Exemplo",
    "zipCode": "00000000",
    "referencePoint": "Perto da praça"
  },
  "hasDisability": true,
  "disabilityType": "Visual",
  "householdCount": 4,
  "childrenCount": 2,
  "hasPets": true,
  "animals": [
    {
      "name": "Rex",
      "type": "cachorro",
      "needsVeterinaryHelp": true
    }
  ]
}

```

# 🔎 Buscar família por ID
curl -X 'GET' \
  'http://localhost:8080/api/FormularioFamilia/1' 


# 🔄 Atualizar família existente
  'http://localhost:8080/api/FormularioFamilia/1' 
  ```json
{
    "id": 1,
    "fullName": "João da Silva",
    "cpf": "123.456.789-00",
    "phone": "(11)91234-5678",
    "address": {
      "id": 1,
      "street": "Rua Exemplo",
      "number": "123",
      "neighborhood": "Bairro Central",
      "city": "Cidade Exemplo",
      "state": "Estado Exemplo",
      "zipCode": "00000000",
      "referencePoint": "Perto da praça"
    },
    "hasDisability": true,
    "disabilityType": "Visual",
    "householdCount": 4,
    "childrenCount": 2,
    "hasPets": false,
    "animals": []
  }'
  ```

# ❌ Deletar família por ID
curl -X 'DELETE' 
  'http://localhost:8080/api/FormularioFamilia/1' 


