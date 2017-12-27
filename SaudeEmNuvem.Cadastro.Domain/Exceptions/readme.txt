Fonte: https://docs.microsoft.com/pt-br/dotnet/standard/microservices-architecture/microservice-ddd-cqrs-patterns/domain-model-layer-validations
Validações são normalmente implementadas em construtores de entidade de domínio ou em métodos que podem atualizar a entidade.
Há várias maneiras de implementar validações, como verificação de dados e aumentando exceções se a validação falhar.
Também há padrões mais avançados, como usando o padrão de especificação para validações e o padrão de notificação para retornar
uma coleção de erros em vez de retornar uma exceção para cada validação conforme ela ocorre.

Mais informações sobre validações e exceções:
https://martinfowler.com/articles/replaceThrowWithNotification.html