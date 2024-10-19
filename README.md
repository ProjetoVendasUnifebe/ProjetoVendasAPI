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
