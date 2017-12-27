Breve definição sobre o padrão Repository
Martin Fowler afirma: "O padrão  Repository faz a mediação entre o domínio e as camadas de mapeamento de dados,
agindo como uma coleção de objetos de domínio em memória.
Conceitualmente, um repositório encapsula o conjunto de objetos persistidos em um armazenamento de dados e as operações realizadas sobre eles,
fornecendo uma visão mais orientada a objetos da camada de persistência
e também da suporte ao objetivo de alcançar uma separação limpa e uma forma de dependência entre o domínio e as camadas de mapeamento de dados."
(http://martinfowler.com/eaaCatalog/repository.html)

Achei um artigo muito interresante do Vinicius Reis falando sobre o padrão:
https://medium.com/by-vinicius-reis/repository-pattern-n%C3%A3o-precisa-ser-chato-principalmente-com-laravel-d97235b31c7e

De acordo com o mesmo, algumas das vantagens do padrão são:
Centralizar regras de recuperação e persistência de dados.
Abstrair a utilização de ORMs possibilitando a troca por outros ORMs
Abstrair o tipo de banco de dados, que assim como ORMs pode ser trocado.
Devolver dados em um formato agnóstico (array ou StdClass), deixando zero acoplamento de ORM.

