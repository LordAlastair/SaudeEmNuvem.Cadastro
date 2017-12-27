Fonte:	https://robsoncastilho.com.br/2014/04/16/introduzindo-a-camada-de-aplicacao/

A camada de aplicação (Application Layer) fornece um conjunto de serviços de aplicação (application services),
os quais expressam as user stories (ou use cases) do software.

De modo simples, um serviço de aplicação recebe dados de seus clientes, como a interface de usuário,
trata esses dados se necessário e chama um objeto do domínio para executar a operação de negócio.

Ele pode ainda fazer o controle de transação e tratar do controle de acesso do software, além de poder enviar notificações para outros softwares.
Sendo assim, ele é um grande coordenador da operação de negócio a ser realizada pelo software e um cliente direto dos objetos de domínio.

(A camada de aplicação também é conhecida por camada de serviço (Service Layer),
como mostrada no clássico livro Patterns of Enterprise Application Architecture do Martin Fowler.)
https://www.amazon.com/Patterns-Enterprise-Application-Architecture-Martin/dp/0321127420

Outro artigo sobre a camada de aplicação:
https://medium.com/saga-do-programador/camada-de-aplica%C3%A7%C3%A3o-domain-driven-design-e-isolamento-do-dom%C3%ADnio-55348fbf1a26