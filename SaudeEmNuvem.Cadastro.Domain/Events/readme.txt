Fonte: https://docs.microsoft.com/pt-br/dotnet/standard/microservices-architecture/microservice-ddd-cqrs-patterns/domain-events-design-implementation
O que é um evento de domínio?

Um evento é algo que tenha ocorrido no passado. Um evento de domínio é, logicamente, algo que ocorreram em um domínio específico,
e algo que você deseja que outras partes do mesmo domínio (em processo).

Uma vantagem importante dos eventos de domínio é que os efeitos colaterais depois algo aconteceu em um domínio podem ser expressos explicitamente em vez de implicitamente.
Esses efeitos devem ser consistentes para acontecem a todas as operações relacionadas à tarefa de negócios de lado, ou nenhum deles.
Além disso, os eventos de domínio permitem uma melhor separação de preocupações entre classes dentro do mesmo domínio.

Por exemplo, se você estiver usando apenas apenas do Entity Framework e entidades ou até mesmo agregações,
se deve haver efeitos colaterais provocados por um caso de uso, aqueles serão implementados como um conceito implícito no código acoplado depois que algo aconteceu.
No entanto, se você apenas vê esse código, você poderá não saber se esse código (o efeito colateral) é parte da operação de principal ou se ela é realmente um efeito colateral.
Por outro lado, usando os eventos de domínio torna o conceito explícita e faz parte da linguagem onipresente.
Por exemplo, no aplicativo eShopOnContainers, criar uma ordem não é praticamente a ordem;
ela atualiza ou cria um comprador de agregação com base no usuário original, porque o usuário não é um comprador até que haja um pedido em vigor.
Se você usar eventos de domínio, você pode expressar explicitamente essa regra de domínio com base no idioma onipresente fornecido pelos especialistas de domínio.