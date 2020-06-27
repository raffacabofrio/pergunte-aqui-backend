# pergunte-aqui-backend

Backend REST Api para o app pergunte aqui. É um projeto simples para mostrar conceitos importantes no desenvolvimento de software.
- Simplicidade.
- Robustez.
- Arquitetura DDD.
- Testes unitários.
- Histórico do git em sequência lógica e educativa.

# Como rodar o projeto?

Não precisa fazer nenhuma configuração. Apenas rode o projeto no visual studio. Faça o mesmo no projeto frontend para experimentar o app completo.

Também é possível rodar por linha de comando.
```bash
dotnet run --project PergunteAqui/PergunteAqui.api
```

# Documentação Swagger

Todos os endpoints estão documentados no swagger. Rode o projeto e abra no seu navegador.

http://localhost:33216

# Modelo desse projeto

Desde 2018 eu tenho contribuído no projeto open source sharebook. Um app para doação de livros. Usei esse projeto como base. Removi tudo que era relacionado a livro. E criei novas entidades e endpoints para atender esse cenário de perguntas e respostas.

# Coisas que podem melhorar

Não tive muito tempo e priorizei a entrega mínima e demonstrar domínio do assunto. O app é realmente simples, sendo o MVP mesmo. Entretanto gostaria de registrar alguns pontos que me incomodam um pouco, e que gostaria de melhorar:
- Usar banco in-memory para os testes. De forma a aumentar a cobertura de testes em todas as camadas. Ficaria até mais fácil de escrever os testes.
- Melhorar a modelagem da entidade Like. Tornar ela genérica para qualquer tipo de conteúdo. Num sistema real a gente precisa pensar mais na escala.
- Incluir suporte ao Docker. Isso ajuda demais tanto o desenvolvimento quanto o deploy mais independente de um cloud específico.
- Suporte a orderBy dinâmico no endpoint de busca de perguntas.

