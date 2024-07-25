<h1 align="center"> Primeira-Aplicacao-MVC </h1>

## :scroll: Sobre: 
Esse repósitorio tem como intuito documentar o aprendizado e o projeto realizado diante do cápitulo 1 do livro "ASP.NET Core MVC: Aplicações modernas em conjunto com o Entity Framework".<br>
Os dados são armazenados em uma única lista e as abas lhe permitem manipular essa lista, adicionando, removendo e editando os dados.<br>

## :newspaper: Features:

- CAPITULO 1
- [x] Entender o básico de MVC
- [x] View para **VER** todas as instituições
- [x] View para **VER 1 ÚNICO** registro de instituição
- [x] View para **ADICIONAR** uma instituição
- [x] View para **EDITAR** os dados de uma instituição
- [x] View para **DELETAR** os dados de uma instituição

- CAPITULO 2
- [x] Criação do Banco de Dados.
- [x] Conexão com o Banco de Dados.

- [X] **VER** todas os departamentos do Banco de dados *MYSQL*.
- [ ] **VER 1 ÚNICO** registro de departamentos do Banco de dados *MYSQL*.
- [X] **ADICIONAR** um departamentos do Banco de dados *MYSQL*.
- [ ] **EDITAR** os dados de um departamentos do Banco de dados *MYSQL*.
- [ ] **DELETAR** os dados de um departamentos do Banco de dados *MYSQL*.

## :scroll:
#### 19/07 - 17:40 
Adicionado o sistema de visualizar, inserir e editar dados.

#### 20/07 - 16:25
Adicionado os sistemas de visualização de 1 único registro por vez e o de deletar o registro.

#### 22/07 - 10:40
Conexão do Banco de dados + Criação direta dele utilizando SQL.

#### 24/07 - 09:00
Substituição do *banco de dados* SQL
Criação do *banco de dados* mysql com MariaDB.
Conexão com o novo banco."

#### 25/07 - 06:27
Criação da view e métodos para ver os departamentos dentro do banco de dados.
Criação da view e métodos para adicionar departamentos dentro do banco de dados.

## ANOTAÇÕES

**ASYNC** = Permite que quem fez a requisição, continue outros processos normalmente.
- Permite a utilização do 'await', assim quem fez a requisição, continua outros processos normalmente, até a conclusão de onde o await está, e então retoma de onde o método havia parado.

#### 25/07 - 06:27 - DepartamentoController - Criação de dados no banco.
```
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create([Bind("Nome")] Departamento departamento){
```
public async Task(IActionResult) = Método que retorna um ActionResult assincrono.

Create([Bind("Nome")] Departamento departamento) = O metodo recebe como parametro um objeto departamento.

**BIND("Nome")** *(bibilioteca LINQ)* = Diz que só vai utilizar a variavel de nome "Nome" do objeto como parametro, e não ele inteiro