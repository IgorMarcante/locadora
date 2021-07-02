## 📝 Projeto
Um exemplo de WebAPI usando ASP.NET Core 5.0 de uma locadora de filme. Está dividido em três projetos:
- Api: Onde é a aplicação de fato
- Dominio: Onde fica toda a camada de entidades e estrutura do banco 
- Tests: Projeto que rodam os teste unitários

### 🚀 Tecnologias utilizadas
Esse projeto foi desenvolvido com as seguintes tecnologias:
- [C#](https://docs.microsoft.com/pt-br/dotnet/csharp/) - Backend
- [.NET CORE 5](https://docs.microsoft.com/pt-br/aspnet/core/?view=aspnetcore-5.0) - Backend(Framework)
- [JwtBearer](https://docs.microsoft.com/pt-br/dotnet/api/microsoft.aspnetcore.authentication.jwtbearer?view=aspnetcore-5.0) - Autenticação/Token
- [Entity Framework](https://docs.microsoft.com/pt-br/ef/) - Banco de dados(Framework/ORM)
- [SQLServer](https://docs.microsoft.com/pt-br/sql/sql-server/?view=sql-server-ver15) - Banco de dados

## 🖱 Instalação 

Para executar esse repositório baixe-o para sua maquina ou de um `Git Clone`

### 🖥 Backend 

- abra a pasta `Api` no Terminal/Prompt de Comando.
- `dotnet restore` esse comando ira restaurar todas as dependencias do projeto
- Configure a instancia do seu Banco de Dados no arquivo appsettings.json
- `dotnet ef database update` esse comando ira criar o banco de dados do projeto
- `dotnet run` esse comando ira rodar o projeto

### 💻 Autenticação

- Crie o primeiro usuario manualmente no banco, informando Login, Senha e a Role(Administrador)
- Em um ferramenta que dá suporte à documentação das requisições feitas pela API, acesse via POST a seguinte URL: `https://localhost:5001/Autenticacao` passando no corpo da requisição as seguintes informações:

```
  {
    "Login": "login criado",
    "Senha": "senha criada"
  }
```
O retorno seguira a seguinte estrutura:
```
{
  "user": {
    "id": 1,
    "login": "admin",
    "senha": "",
    "role": "Administrador"
  },
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImFkbWluIiwicm9sZSI6IkFkbWluaXN0cmFkb3IiLCJuYmYiOjE2MjUxODMyNTEsImV4cCI6MTYyNTE5MDQ1MSwiaWF0IjoxNjI1MTgzMjUxfQ.zMg8qZE5wrM101_OfVW8LLBBKUyzsZKjEt3nk8525Uw"
}
```
O token é utilizado para conseguir fazer as solicitações nos metodos que necessitam autorização.

#### Utilizando o token
- Na configuração de HEADER de sua ferramenta para requisições a API, configure da seguinte forma:

 Nome: Authorization  
 Value: Bearer tokenGeradoAnteriormente
 
 ### 💻 Metodos disponiveis
 (Lembre de sempre configurar o TOKEN conforme citado acima, para todos os metodo que for fazer algum tipo de requisição.)  
 
 ###### Genero
 - **GET:** `https://localhost:5001/Genero`
 - **POST:** `https://localhost:5001/Genero`  
 O POST espera a seguinte entrada no body:  
 ```
  {
  "nome": "string",
  "dataCriacao": "2021-07-01",
  "ativo": true
}
```
- **PUT:** `https://localhost:5001/Genero/{id}`  
```
{
  "id": 0,
  "nome": "string",
  "dataCriacao": "2021-07-02T02:44:58.119Z",
  "ativo": true
}
```
- **DELETE:** `https://localhost:5001/Genero/{id}`

###### Filme
 - **GET:** `https://localhost:5001/Filme`
 - **POST:** `https://localhost:5001/Filme`  
 O POST espera a seguinte entrada no body:  
 ```
{
  "nome": "string",
  "dataCriacao": "2021-07-01",
  "ativo": true,
  "generoId": 4
}
```
- **PUT:** `https://localhost:5001/Filme/{id}`  
```
{
  "id": 2,
  "nome": "string",
  "dataCriacao": "2021-06-30",
  "ativo": false,
  "generoId": 5
}
```
- **DELETE:** `https://localhost:5001/Filme/{id}`
- **DELETE(VARIOS):** `https://localhost:5001/Filme/Filme?id={ID}&id={ID}`

###### Locação
 - **GET:** `https://localhost:5001/Locacao`
 - **POST:** `https://localhost:5001/Locacao`  
 O POST espera a seguinte entrada no body:  
 ```
{
	"Locacao":
	 {
		"CPF": "123.123.123-12",
		"dataLocacao": "2021-07-01"
		},
		 "filmeId":[{idFIlme},{idFIlme}]
}
```
 ### 🚀 Live - Online
 O acesso online deve ser feito igual instruido anteriormente, porém, no local do  `https://localhost:5001` usar  `https://igor2107012315.bateaquihost.com.br`
###### Autenticação
`https://igor2107012315.bateaquihost.com.br/Autenticacao/`  
Usuario e Senha padrão disponivel:
 ```
{
	"Login": "admin",
	"Senha": "123456"
}
```
###### Genero
`https://igor2107012315.bateaquihost.com.br/Genero/`
###### Filme
`https://igor2107012315.bateaquihost.com.br/Filme/`
###### Locacao
`https://igor2107012315.bateaquihost.com.br/Locacao/`
<hr>

### 📱 Contato / Redes Sociais 

<p align="center">
   <a href="https://github.com/igormarcante" target="_blank" >
    <img alt="Github" src="https://img.shields.io/badge/Github--%23F8952D?style=social&logo=github"></a> 
  
  <a href="https://instagram.com/igormarcante" target="_blank" >
    <img alt="Instagram" src="https://img.shields.io/badge/Instagram--%23F8952D?style=social&logo=instagram"></a> 
  
  <a href="https://www.linkedin.com/in/igor-marcante-85ab1190/" target="_blank" >
    <img alt="Linkedin" src="https://img.shields.io/badge/Linkedin--%23F8952D?style=social&logo=linkedin"></a> 
  
  <a href="mailto:igormarcante@gmail.com" target="_blank" >
    <img alt="Email" src="https://img.shields.io/badge/Email--%23F8952D?style=social&logo=gmail"></a> 
</p>

