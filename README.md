# Projeto Vendas - Arquitetura DDD📞

Este projeto é baseado nos princípios de Domain-Driven Design (DDD), seguindo uma estrutura em camadas bem definida. Cada camada tem uma responsabilidade clara e ajuda a manter a separação de preocupações, facilitando a manutenção e evolução do software.

## Camadas do Projeto

### 1. Vendas.API
A camada **Vendas.API** é responsável por expor as funcionalidades do sistema por meio de uma interface HTTP (API REST). Ela lida com as requisições dos clientes e direciona essas requisições para as camadas mais internas do sistema.

**Principais componentes:**
- **Controllers**: Responsáveis por receber e processar as requisições HTTP, chamando os serviços apropriados na camada de aplicação.
- **Program.cs**: Contém a configuração inicial da aplicação e os serviços registrados para injeção de dependências.
- **appsettings.json**: Arquivo de configuração da aplicação, como strings de conexão, configurações de logging, etc.

### 2. Vendas.Application
A camada **Vendas.Application** contém a lógica de aplicação do sistema. Ela orquestra as operações de negócio e lida com as interações entre as diferentes partes do sistema.

**Principais componentes:**
- **Interfaces**: Define contratos de serviços que serão implementados nesta camada e utilizados pelos controladores da API.
- **Mappers**: Responsáveis por converter objetos de uma camada para outra, garantindo que os dados fluam corretamente entre as diferentes partes do sistema.
- **Services**: Implementam a lógica de negócio necessária para atender as requisições vindas dos controladores da API.

### 3. Vendas.Domain
A camada **Vendas.Domain** é o coração do sistema, onde estão as regras de negócio e entidades fundamentais. Esta camada é independente de outras, garantindo que o domínio do negócio não seja afetado por mudanças em tecnologias externas.

**Principais componentes:**
- **Entities**: Representam os objetos de negócio do sistema (e.g., Cliente, Pedido).
- **DTOs**: Data Transfer Objects, utilizados para transferir dados entre as camadas.
- **Enums**: Define enumeradores utilizados pelo domínio para facilitar a leitura e o entendimento do código.
- **Interfaces**: Define contratos que serão implementados por serviços ou repositórios, permitindo uma fácil troca de implementações.

### 4. Vendas.Infra
A camada **Vendas.Infra** cuida da comunicação com as fontes de dados, como bancos de dados ou APIs externas. Ela é responsável pela persistência dos dados e implementação dos repositórios que a camada de domínio utiliza.

**Principais componentes:**
- **Context**: Contém o DbContext, que representa a sessão com o banco de dados, e é responsável por realizar as operações de leitura e gravação.
- **Mappings**: Configura os mapeamentos entre as entidades do domínio e as tabelas do banco de dados.
- **Repositories**: Implementam os repositórios definidos no domínio, fornecendo os métodos de acesso a dados necessários pelas demais camadas.

## Estrutura do Projeto

A arquitetura do projeto segue o padrão de separação de responsabilidades:

- A **API** é responsável pela comunicação externa.
- A **Application** gerencia a lógica de aplicação e orquestra os casos de uso.
- O **Domain** contém o núcleo do negócio e as regras de domínio.
- O **Infra** lida com a persistência e as operações de dados.

# Padronização de retorno dos endPoint's
## 1 - GET
- Para consuta de mais de um elemento, é retornado um list, caso n seja encontrado nenhum, retorne NoContent() - 204
- Para consulta de apenas um unico elemento, deve-se retornar as informações específicas do elemento pesquisado, caso não encontre o mesmo, retorne NoContent() - 204
## 2 - POST
- Para criação de um elemento, é pedido um DTO de entrada, sem o parametro de Id, assim no service é feita a converção para um model e assim inserido na tabela. A mesma endPoint deve retornar Ok(boolean) para o sucesso do cadastro e BadRequest(boolean) para alguma eventual falha no cadastro.
## 3 - PUT 
- Para a alteração de um elemento de uma tabela, é solicitado um model do elemento que será alterado. 
- Será usado o id do model para fazer uma pesquisa se o id selecionado pertence a um registro valido na tabela, em caso negativo, deve retornar um BadRequest(String indicando o erro). Em caso positivo, será feita a busca das informações do id selecionado.
- Caso o campo vindo como parametro esteja nulo, não deve ser alterado o campo da tabela, caso contrario, com qualquer elemento recebido como parametro preenchido, deve-se alterar na coluna do banco. Retornando da endpoint um Ok(string demostrando sucesso de alteração)
- Em caso de falha no momento de salvar as alterações o sistema deve retornar um BadRequest(string indicando o erro)
  ## 4 - Delete
- O sistema deve exigir um id de parametro de entrada, onde será feita uma consulta se aquele id pertence a algum registro de tabela. Em caso negativo, retorna um BadRequest(boolean). Já em caso positivo, o sistema deve retornar Ok(boolean) indicando que a operação foi realizada com sucesso
