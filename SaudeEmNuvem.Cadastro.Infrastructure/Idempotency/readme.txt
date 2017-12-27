Fonte: http://www.itnerante.com.br/profiles/blogs/rest-x-http-2-caracter-sticas-http-m-todos-status-code-idempot
Mais informações sobre o assunto em : https://www.infoq.com/br/news/2013/05/idempotent

Breve definição de idempotente:
A principal característica para afirmarmos se um recurso é idempotente ou não,
é avaliarmos se as alterações ocasionadas pela requisição de um recurso não provocam efeitos diferentes no banco de dados.
Vamos exemplificar: Imagine que vamos criar um recurso GET com a seguinte instrução: "SELECT * FROM CLIENTES".
Perceba que esta requisição terá o mesmo efeito no banco de dados todas as vezes que for executada.
Da mesma forma se utilizássemos como exemplo a alteração ou exclusão de um recurso, não provocaria efeito diferente no banco de dados,
perceba que esse conceito não tem nada a ver com atualização ou não de registros.
Entretanto, se utilizarmos numa requisição, uma instrução SQL para inserir registros, essa requisição irá provocar efeitos diferentes no banco de dados,
pois cada vez que for executada estará aumentando o tamanho da tabela. Logo não é idempotente.