# 🚛 LogisticERP

Um sistema de **gestão logística** feito em **.NET + Entity Framework Core**, pensado para ajudar empresas de transporte e logística a organizar seus **motoristas, veículos e viagens** de forma simples e eficiente.  

---

## ✨ Funcionalidades
- 👨‍✈️ **Gestão de Motoristas**: cadastre, edite e acompanhe a situação de cada motorista.  
- 🚚 **Controle de Veículos**: mantenha informações sobre a frota, manutenção e disponibilidade.  
- 🛣️ **Gerenciamento de Viagens**: planeje rotas, associe motoristas e veículos, e acompanhe cada viagem.  
- 📊 **Relatórios inteligentes** (em breve): visualize indicadores para melhorar a eficiência logística.  

---

## 🏗️ Entidades Principais
- **Motorista** 👨‍✈️  
  Dados pessoais, habilitação, disponibilidade.  

- **Veículo** 🚛  
  Modelo, placa, capacidade, manutenção.  

- **Viagem** 🛣️  
  Origem, destino, motorista e veículo associado.  

---

## 🛠️ Tecnologias
- ⚙️ **.NET 9**  
- 🗄️ **Entity Framework Core (MySQL)**  
- 🌱 **Migrations para versionamento do banco**  
- 🔐 **Variáveis de ambiente (.env) para segurança**  

---

## 🚀 Como rodar o projeto

1. Clone o repositório:
   ```bash
   git clone https://github.com/rodrigogrisi/LogisticERP.git
2. Navegue até a pasta do projeto:
   ```bash
   cd LogisticERP
   
3. Configure o arquivo .env (na raiz do projeto):
    ```bash
    content: DB_CONNECTION=Server=...;Port=3306;Database=...;User=...;Password=...

4. Execute as migrations para criar/atualizar o banco:
    ```bash
    dotnet ef database update

5. Rode o projeto
    ```bash
    dotnet run

6. Acesse no navegador:
    ```bash
    🌐 http://localhost:5000
    🔒 https://localhost:7000

---
