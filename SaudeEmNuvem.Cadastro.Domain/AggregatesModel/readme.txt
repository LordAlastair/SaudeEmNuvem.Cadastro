Fonte: http://www.agileandart.com/2010/07/16/ddd-introducao-a-domain-driven-design/
Agregados são compostos de Entidades ou Objetos de Valores que são encapsulados numa única classe.
O Agregado serve para manter a integridade do modelo.
Elegemos uma classe para servir de raiz do Agregado,
quando algum cliente quiser manipular dados de uma das classes que compõem o Agregado, essa manipulação só poderá ser feita através da raiz;