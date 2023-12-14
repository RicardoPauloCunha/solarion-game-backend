# SolarionGame

Solarion Chronicles: The Game, uma aventura de narrativa interativa (jogo de escolhas) baseado em um evento presente no jogo 'Stardew Valley'.

O intuito dessa série de repositórios é possuir um projeto atual com bibliotecas e práticas que trabalho normalmente, para usar como base em outros projetos ou até servir de início para novos, como uma forma de 'template'.

## Principais funcionalidades

* Criar/Editar conta de usuário;
* Realizar login;
* Recuperar senha;
* Salvar pontuação obtida;
* Listar pontuações;
* Buscar dados necessários para a dashboard das pontuações (admin);

## Repositórios relacionados

* [solarion-game-frontend-web](https://github.com/RicardoPauloCunha/solarion-game-frontend-web)
* [solarion-game-frontend-mobile](https://github.com/RicardoPauloCunha/solarion-game-frontend-mobile)

## Pré-requisitos

* .NET 6.0
* MySQL

# Executando o projeto

1. Clone o repositório:

```bash
git clone https://github.com/RicardoPauloCunha/solarion-game-backend
```

2. Execute o arquivo `SolarionGame.sln` para abrir o projeto no Visual Studio 2022;

3. Abra o arquivo `SolarionGame.Api/appsettings.Development.json` (provavelmente aninhado com appsettings.json) para adicionar as configurações do ambiente de desenvolvimento (`SolarionGame.Api/appsettings.json` para produção);

4. Em `ConnectionStrings.DefaultConnection`, altere o texto **DATABASE_CONNECTION_HERE** para a string de conexão com o banco de dados MySQL (exemplo: "server=127.0.0.1; port=3306; database=NOME_BANCO_DADOS; user=USUARIO; password=SENHA;");

5. Em `TokenSetting`, faça as seguintes alterações:

* `Secret` trocar **JWT_TOKEN_SECRET_HERE** por uma chave secreta para o JWT (exemplo: "MINHA_CHAVE_SECRETA_SUPER_GRANDE");
* `Issuer` trocar **BACKEND_URL_HERE** pela URL do backend (exemplo: "http://localhost:5000");
* `Audience` trocar **FRONTEND_URL_HERE** pela URL do frontend web (exemplo: "http://localhost:3000");

6. Caso não queira ativar o serviço de email, em `MailSetting.ActiveMail` coloque o valor **false** e pule para o passo 8.

7. Para ativar o serviço de email, em `MailSetting`, faça as seguintes alterações:

* `ActiveMail` coloque o valor **true**;
* `Sender.Email` trocar **MAIL_ACCOUNT_HERE** pelo email da conta que vai enviar as mensagens (dependendo do provedor de email é necessário configurar o envio de mensagens por SMTP);
* `Sender.Password` trocar **MAIL_PASSWORD_HERE** pela senha de acesso de email utilizado;
* Caso necessário, em `Smtp` trocar os valores de Host e Port pelos dados do provedor correspondente;

8. Acesse o terminal de pacotes clicando em:

* Ferramentas
* Gerenciador de Pacotes do NuGet
* Console do Gerenciador de Pacotes

9. Execute o comando para gerar a migration (Sol1214 é só um nome para migration):

```bash
add-migration Sol1214
```

10. Em seguida, o comando para aplicar a migration no banco de dados:

```bash
update-database
```

11. Execute o projeto apertando **F5** ou clicando no botão de play **SolarionGame.Api**. 

12. Acesse [http://localhost:5000/swagger/index.html](http://localhost:5000/swagger/index.html) e execute algum endpoint para verificar se a configuração foi realizada corretamente.

# Criando conta de ADMIN

No momento não é possível cadastrar um usuário do tipo **Admin** diretamente.

1. Nesse caso, cadastre um usuário comum através do endpoint **/api/users (POST)**;

2. Depois acesse a tabela **tb_user** no banco de dados e altere a coluna **UserType** do usuário criado para **1** (1 representa o ENUM do Admin);

3. Por fim, salve as alterações e realize login para verificar a "criação" do Admin, deverá ser possível realizer a requisição para buscar os dados para a dashboard através do endpoint **/api/scores/all/indicators (GET)**.