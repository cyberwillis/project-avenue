# AvenueEntrega

## Motivação
O projeto teve como tecnologia escolhida a plataforma Asp.net. 
Primeiramente por ser a linguagem que tenho mais facilidade para implementações.
Segundo por existir um fator de risco desconhecido para mim na aplicação de Python em determinadas areas deste projeto que me fariam levar bem mais do que o tempo estimado.

Acredito que a definição de um problema deva ser analisado cautelosamente antes de se definir a plataforma, pois uma vez feita a escolha, para um modulo dificilmente será fácil altera-la.
Então para este teste optei por uma segregação de responsabilidades e desenvolvi com duas premissas em mente:

1-	Disponibilizar um portal para carregamento de arquivos de mapas pelo administrador do sistema. Até este ponto, não coloquei segurança de usuário para não haver necessidade de mais integrações como por exemplo questões do tipo:
Usuário local ou relacionado ao usuário de rede de um ambiente coorporativo onde suas permissões de aplicações definidas no LDAP possam ser importadas e libere acesso ao serviço de carregamento de mapa?
Visando fugir destas questões mais complexas por não ter toda a visão do negocio, me concentrei na arquitetura do sistema e suas funcionalidades principais.

2-	Disponibilizar um WebService (API) em que uma aplicação mobile ou um sistema externo pudesse ser desenvolvido para acessar este dado.

## O desenvolvimento do portal segue a arquitetura em CRUD - N camadas (Onion Arquitecture):

### 1-	Infrastructure Layer
a.	AvenueEntrega.I18N (Internacionalização)

b.	AvenueEntrega.Infrastructure (suporte para internacionalização)

### 2-	Domain Model Layer
a.	AvenueEntrega.Model (Modelo de domínio baseado nos requisitos – modelo pobre sem metodos)

b.	AvenueEntrega.Rules (Regras de negocio para o domínio)

c.	AvenueEntrega.Rules.UnitTest (Testes básicos para validação apenas da lógica de encontrar a melhor rota por custo)

### 3-	Repository Layer
a.	AvenueEntrega.RepositoryFile (Camada de persistência de arquivo txt)

b.	AvenueEntrega.RepositoryNHibernate (Camada de persistência ORM para modelos de classes do sistema)

c.	AvenueEntrega.RepositoryNHibernate.IntegratesTest (Camada para testes com banco de dados e persistencia)

### 4-	Services Layer
a.	AvenueEntrega.DataContracts (camada de classes responsável por mensagerias trocadas entre o sistema do modelo e serviços)

b.	AvenueEntrega.Service.ETL (camada responsável por instanciar o repositório de arquivo e tratar o arquivo txt enviado antes de persisti-lo)

c.	AvenueEntrega.Service.ETL.IntegratedTest

d.	AvenueEntrega.ServiceContracts (Contrato de serviços utilizados pelo portal e pela API - WebServices)

e.	AvenueEntrega.Services (contém os serviços principais da aplicação)

f.	AvenueEntrega.Services.UnitTest (Teste unitário na camada de serviço e mock de dados)

### 5-	Presentation Layer
a.	AvenueEntrega.Web.MVC (portal de interação , envio de arquivo de map e busca por melhor rota)

b.	Avenie.Entrega.Web.WCF (API para consumo por outros sistemas, sem envio de mapa)


### Obs: 
Instruções e detalhes sobre o projeto podem ser encontrados na pasta Documentation, dentro da solução.
Lá tem informações desde a motivação e detalhes sobre a arquitetura até como instalar e configurar a aplicação.



# Video (Solution)

https://www.youtube.com/watch?v=xJgg10dGt4Q
