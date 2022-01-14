# Teste Backend V2 - Aiko

### Como baixar e rodar o projeto?

#### O que precisa?
Faça o [download](https://dotnet.microsoft.com/download/dotnet/5.0) do SDK ou Runtime do .NET.  

#### Clone o repositório e acesse o diretório
```bash
$ git clone https://github.com/evertonandrade/teste-backend-v2/tree/teste/jose-everton-andrade && cd teste-backend-v2
```

#### Para rodar com a CLI do .NET execute:
```bash
$ dotnet run -p src/App
```

#### Acesse a aplicação em:
- [https://localhost/5001](https://localhost:5001)  


### Swagger da API
- [https://localhost/5001/swagger](https://localhost:5001)


#### Para rodar com o Docker
```
$ docker-compose up --build
```
#### Acesse a aplicação em:
- [http://localhost/5000](http://localhost:5000)

OBS: Caso a aplicação não funcione, execute apenas os container do postgres e utilize a sdk do .NET pra rodar a aplicação.

**IMPORTANTE: Restaurar o banco antes de iniciar a aplicação**

### Restaurando o Banco

Acesso o container do postgres com:
```bash
$ docker exec -it container_postgres bash
```

Local dos scripts:
```
cd docker-entrypoint-initdb.d/sql
```

Exemplo de como restaurar o banco utilizando o `pg_restore`:
```
pg_restore -U postgres -d aikodb -1 data.backup
```

---