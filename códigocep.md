<!DOCTYPE html>
<html lang="pt">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>
<body>
<form action="/cadastrar" method="POST" onsubmit="return validarForm()">
    <label for="cep">Cep</label><br>
    <input id="cep" onblur="alert(this.value)" type="text" maxlength="11"><br>
    <label for="bairro">Bairro</label><br>
    <input type="text" id="bairro"><br>
    <label for="ddd">ddd</label><br>
    <input type="text" id="ddd"><br>
    <label for="localidade">Localidade</label><br>
    <input type="text" id="localidade"><br>
    <label for="logradouro">Logradouro</label><br>
    <input type="text" id="logradouro"><br>
    <label for="uf">Uf</label><br>
    <input type="text" id="uf"><br>
    <label for="numero">Numero</label><br>
    <input type="text" id="numero"><br>
    <label for="cpf">CPF</label><br>
    <input type="text" id="cpf" name="cpf"><br>
    <label for="profissao">Profissao</label><br>
    <input type="text" id="profissao"><br>
    <input type="submit" value="Enviar">

<script src="/js/validacoes.js"></script>

</form>

<script>
// Exemplo de JavaScript inicial para desativar envios de formulário, se houver campos inválidos.
(function() {
  'use strict';
  window.addEventListener('load', function() {
    // Pega todos os formulários que nós queremos aplicar estilos de validação Bootstrap personalizados.
    var forms = document.getElementsByClassName('needs-validation');
    // Faz um loop neles e evita o envio
    var validation = Array.prototype.filter.call(forms, function(form) {
      form.addEventListener('submit', function(event) {
        if (form.checkValidity() === false) {
          event.preventDefault();
          event.stopPropagation();
        }
        form.classList.add('was-validated');
      }, false);
    });
  }, false);
})();
</script>
</body>

</html>
