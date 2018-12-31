# ProgramaPontos
Aplicação simples para demonstração da utilização de CQRS + EventSourcing.

Esta aplicação tem a finalidade de mostrar através de uma regra de programa de pontos como o CQRS + EventSourcing pode ser implementado. O domínio foi modelado utiizando o Domain Driven Design (DDD).

Nesta aplicação está sendo utilizado
<ul>
<li><b>RabbitMQ</b> como serviço de mensageria</li>
<li><b>Elastic Search</b> como base leitura (Read Model)</li>
<li><b>MongoDB</b> como EventStore</li>

O arquivo docker\run_containers.bat cria todos os containers necessário para executar a aplicação.
