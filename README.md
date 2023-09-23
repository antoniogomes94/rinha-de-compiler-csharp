# Interpretador para a Rinha de Compiladores

Compiladores e interpretadores é um tempo que eu nunca tinha me aprofundado, tem sido muito legal a busca por esses conhecimentos.

Espero no mínimo1 conseguir fazer o pior compilador (ou intepretador kk) do mundo.

Essa é minha humildo implementação em C# (.NET 6) de um interpretador da Árvore Sintática Abstrata (AST) da linguagem [Rinha de Compiladores](https://github.com/aripiprazole/rinha-de-compiler/).


## Como usar

Utilize o comando abaixo para criar a imagem do docker:

```bash 
docker build -t rinha .
```

Utilize o comando docker run como mostrado a seguir para criar e rodar o container. O parâmetro ```--rm``` exclui o container ao final da execução. Os AST da pasta files foram movidaos para dentro do Container de modo a facilitar os testes. Basta informar o nome do arquivo json durante a chamada.

- fib
```bash
docker run -it --rm rinha files/fib.json
```

- sum
```bash
docker run -it --rm rinha files/sum.json
```

- combination
```bash
docker run -it --rm rinha files/combination.json
```

- print
```bash
docker run -it --rm rinha files/print.json
```
## Funcionalidades do Interpretador

- [ ] Call
- [ ] Function
- [x] Let
- [x] Var
- [x] Bool
- [x] Int
- [x] Str
- [x] Binary
- [x] If
- [x] Print
- [ ] Tuple
- [ ] First
- [ ] Second
