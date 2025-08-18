<!DOCTYPE html>
<html lang="pt-br">
<head>
<meta charset="UTF-8">
<meta name="viewport" content="width=device-width, initial-scale=1">
<title>Cadastro Completo - Pizzaria</title>
<style>
  /* Seu CSS já existente, mantendo layout bonito */
  body { font-family: 'Segoe UI', sans-serif; background:#f0f2f5; padding:20px; display:flex; flex-direction:column; align-items:center;}
  h1 { color:#333; margin-bottom:15px; }
  form { background:white; padding:20px; border-radius:8px; width:350px; box-shadow:0 2px 10px rgb(0 0 0 / 0.1); }
  form > div { margin-bottom:15px; position:relative; }
  label { display:block; margin-bottom:6px; font-weight:600; color:#555; }
  input { width:100%; padding:8px 12px; font-size:1rem; border:2px solid #ccc; border-radius:4px; transition:border-color 0.3s ease; }
  input:focus { border-color:#007bff; outline:none; }
  .error { color:#e74c3c; font-size:0.85rem; position:absolute; bottom:-18px; left:0; }
  button { background:#007bff; color:white; border:none; padding:12px; font-weight:700; font-size:1.1rem; width:100%; border-radius:4px; cursor:pointer; transition: background-color 0.25s ease; }
  button:hover { background:#0056b3; }
  .message { margin-top:15px; font-weight:700; text-align:center; padding:12px; border-radius:5px; display:none; }
  .message.success { background-color:#d4edda; color:#155724; }
  .message.error { background-color:#f8d7da; color:#721c24; }
</style>
</head>
<body>

<h1>Cadastro de Usuário</h1>

<form id="formCadastro" novalidate>
  <div>
    <label for="nome">Nome</label>
    <input type="text" id="nome" name="nome" required minlength="3">
    <div class="error" id="erroNome"></div>
  </div>
  <div>
    <label for="email">E-mail</label>
    <input type="email" id="email" name="email" required>
    <div class="error" id="erroEmail"></div>
  </div>
  <div>
    <label for="senha">Senha</label>
    <input type="password" id="senha" name="senha" required minlength="6">
    <div class="error" id="erroSenha"></div>
  </div>
  <div>
    <label for="telefone">Telefone</label>
    <input type="tel" id="telefone" name="telefone" required pattern="^\\+?[0-9\\s\\-]{8,15}$">
    <div class="error" id="erroTelefone"></div>
  </div>
  <button type="submit">Cadastrar</button>
</form>

<div class="message" id="msgResultado"></div>

<script>
const form = document.getElementById('formCadastro');
const msgResultado = document.getElementById('msgResultado');

form.addEventListener('submit', async (e) => {
  e.preventDefault();

  const dados = {
    Nome: form.nome.value.trim(),
    Email: form.email.value.trim(),
    Senha: form.senha.value.trim(),
    Telefone: form.telefone.value.trim(),
  };

  try {
    const res = await fetch('https://pizzaria-drb5.onrender.com/api/Usuarios', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(dados),
    });

    if (!res.ok) {
      const erro = await res.json().catch(() => ({}));
      throw new Error(erro.message || 'Erro ao cadastrar');
    }

    msgResultado.textContent = 'Cadastro realizado com sucesso!';
    msgResultado.className = 'message success';
    msgResultado.style.display = 'block';
    form.reset();

  } catch (error) {
    msgResultado.textContent = 'Erro: ' + error.message;
    msgResultado.className = 'message error';
    msgResultado.style.display = 'block';
    console.error(error);
  }
});
</script>

</body>
</html>
