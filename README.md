# Descrição

Segunda etapa do processo para Engenharia de Software Backend Sênior - Desafio técnico
https://github.com/itidigital/backend-challenge

## Problema

Considere uma senha sendo válida quando a mesma possuir as seguintes definições:

- Nove ou mais caracteres
- Ao menos 1 dígito
- Ao menos 1 letra minúscula
- Ao menos 1 letra maiúscula
- Ao menos 1 caractere especial
  - Considere como especial os seguintes caracteres: !@#$%^&*()-+
- Não possuir caracteres repetidos dentro do conjunto

Exemplo:  

```c#
IsValid("") // false  
IsValid("aa") // false  
IsValid("ab") // false  
IsValid("AAAbbbCc") // false  
IsValid("AbTp9!foo") // false  
IsValid("AbTp9!foA") // false
IsValid("AbTp9 fok") // false
IsValid("AbTp9!fok") // true
```

> **_Nota:_**  Espaços em branco não devem ser considerados como caracteres válidos.

## Proposta

Construa uma aplicação que exponha uma api web que valide se uma senha é válida.

Input: Uma senha (string).  
Output: Um boolean indicando se a senha é válida.


## Solução

Para a solução do problema, foi utilizado a tecnologia .NET Core.
Visando melhor evolução, extensão e divisão de responsabilidades entre os componentes da aplicação, foram desevolvindos dois componentes:
- Validator
- ItiChallengeApi

Conforme o nome sugere, o componente Validator é uma classlib responsável apenas por conter a estrura das classes Validator e Validated.
Essa separação permite que essa classlib seja utilizada em qualquer projeto que utilize do mesmo objeto de negócio, mantendo um código sincronizado entre as frentes.

O Componente ItiChallengeApi expõe o endpoint de validação da senha, utilizando o pacote Validator para utilizar as regras de negócio da biblioteca.

Desta forma, em um projeto "de verdade", teríamos um componente único de validação e classes de negócio para serem utilizadas em quantas frentes e componentes fossem necessários. Isso é especialmente útil em bibliotecas como de criptografia, autenticação, integrações, entre outros, onde as regras são as mesmas entre diversas peças de um sistema.

O ideal seria disponibilizar esse pacote em alguma ferramenta de gerenciamento de pacotes interna, como um NuGet, Maven ou NPM internos, entre outros.


# Pacote Validator

A lib Validator contém, fundamentalmente, duas interfaces: IValidator e IValidated.

Para a implementação de uma regra de negócio, foi utilizada o padrão DDD, onde o desenvolvimento e estruturação do projeto deve seguir a classificação de negócio (Domain). Portanto, a construção das regras e estruturas referente à funcionalidade de senha foi desenvolvida na pasta "Password".

## IValidator

É responsável por encapsular o método "Validate" e garantir que o tipo genérico T seja utilizado.
No exemplo, a classe PasswordValidator é construída em cima dessa estrutura, que aplica as regras definidas para a validação de senha no desafio.
No caso de uma evolução na solução, como por exemplo aplicar diferentes configurações para a senha, apenas a classe PasswordValidator deverá ser alterada para incluir essa implementação, não necessitando mexer na classe de Password ou na API ItiChallengeApi.

## IValidated

É responsável por utilizar da estrutura Validator para gerenciar sua validade. Esta interface deverá ser implementada por todos os objetos de negócio que o desenvolvedor deve realizar validações.

# Pacote ItiChallengeApi

É o serviço que expõe o endpoint /password/validate.
Desenvolvido em ASP.NET Core, segue a organização do namespace Validation com o ValidationController.
Usa as bibliotecas Newtonsoft para manipulação de JSON e Swashbuckle para scaffolding do Swagger.
