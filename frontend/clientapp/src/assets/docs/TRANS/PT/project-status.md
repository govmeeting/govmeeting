<ul>
<li> Um número de partes do software é implementado (mas precisa ser aprimorado). </li>
<li> É necessário implementar várias partes críticas. </li>
</ul><h1> Implementado </h1>
<ul>
<li> Projeto geral do sistema </li>
<li> Bibliotecas de componentes </li>
<li> Modelo de dados / design de banco de dados relacional. </li>
<li> Scripts de compilação e publicação </li>
</ul><h2> A parte dianteira </h2>
<ul>
<li> Design da interface do usuário </li>
<li> Estrutura para navegação e painel </li>
<li> Componente para revisar uma transcrição </li>
<li> Componente para adicionar tags a uma transcrição </li>
<li> Componente para procurar uma transcrição processada </li>
<li> Espaços reservados para vários outros componentes </li>
<li> Ver modelos </li>
<li> Serviços de mensagens </li>
</ul><h2> Processo interno </h2>
<ul>
<li> API da Web do Asp.Net </li>
<li> Estrutura de processamento do fluxo de trabalho .Net </li>
<li> Transcreva uma gravação de reunião usando o Google Speech Services. </li>
<li> Rotinas de acesso ao Google Cloud. </li>
<li> Processe automaticamente uma transcrição de cidade existente e extraia as informações. </li>
<li> Rotinas de acesso a banco de dados e arquivos </li>
<li> Repositórios para abstrair o acesso a arquivos e bancos de dados </li>
<li> Componente para lidar com vários backups durante a edição da transcrição </li>
<li> Registro de mensagens </li>
</ul><h2> Autenticação </h2>
<ul>
<li> Registro e login do usuário </li>
<li> Autenticação de dois fatores e logins de terceiros </li>
<li> Autorização de chamadas de API da Web </li>
</ul><h1> Ser implementado </h1>
<ul>
<li> <b>Componentes críticos</b> - essenciais para que o software seja utilizável. </li>
<li> <b>Melhorias necessárias</b> - importante para facilitar a usabilidade. </li>
<li> <b>Prioridade</b> - agregaria muito valor. </li>
<li> <b>Extras</b> - pode ser adicionado mais tarde. </li>
</ul><h2> Componentes críticos </h2>
<ul>
<li> Componente para recuperar transcrições e gravações online. <a href="https://github.com/govmeeting/govmeeting/issues/83">Edição 83</a> </li>
<li> Implemente o recurso "Registrar entidade do governo". <a href="https://github.com/govmeeting/govmeeting/issues/62">Edição 62</a> </li>
<li> Recurso Trabalho em andamento. <a href="https://github.com/govmeeting/govmeeting/issues/58">Edição 58</a> </li>
<li> Implemente o recurso Alertas do usuário. <a href="https://github.com/govmeeting/govmeeting/issues/20">Edição 20</a> </li>
<li> Suporte multi-idiomas. <a href="https://github.com/govmeeting/govmeeting/issues/16">Edição 16</a> </li>
<li> Componente para identificar subdivisões políticas da localização do usuário. <a href="https://github.com/govmeeting/govmeeting/issues/13">Edição 13</a> </li>
<li> Capture informações adicionais do usuário durante o registro do usuário. <a href="https://github.com/govmeeting/govmeeting/issues/47">Edição 47</a> </li>
<li> Implemente um componente "Gerente". <a href="https://github.com/govmeeting/govmeeting/issues/84">Edição 84</a> </li>
<li> Projete e implemente um sistema de "reputação". <a href="https://github.com/govmeeting/govmeeting/issues/77">Edição
# 77</a> </li>
</ul><h2> Melhorias necessárias </h2>
<ul>
<li> Melhore a precisão do reconhecimento de voz. <a href="https://github.com/govmeeting/govmeeting/issues/66">Edição 66</a> </li>
<li> Melhorar a interface do usuário de Revisão. <a href="https://github.com/govmeeting/govmeeting/issues/">Questão #</a> </li>
<li> Melhore a interface do usuário Adicionar tags. <a href="https://github.com/govmeeting/govmeeting/issues/">Questão #</a> </li>
<li> Melhorar a interface do usuário do View Meeting. <a href="https://github.com/govmeeting/govmeeting/issues/">Questão #</a> </li>
<li> Baixe e processe imagens panorâmicas para cabeçalhos de localização. <a href="https://github.com/govmeeting/govmeeting/issues/76">Edição 76</a> </li>
</ul><h2> Prioridade </h2>
<ul>
<li> Aplicativo móvel para gravar uma reunião. <a href="https://github.com/govmeeting/govmeeting/issues/18">Edição 18</a> </li>
<li> Aplicativo móvel para usar comandos de voz para revisar uma reunião. <a href="https://github.com/govmeeting/govmeeting/issues/55">Edição 55</a> </li>
<li> Addtags - torná-lo um processo de duas etapas? <a href="https://github.com/govmeeting/govmeeting/issues/67">Edição 67</a> </li>
<li> Addtags - filtre a visualização por seção. <a href="https://github.com/govmeeting/govmeeting/issues/65">Edição 65</a> </li>
<li> Localize transcrições ou gravações online existentes. <a href="https://github.com/govmeeting/govmeeting/issues/13">Edição 13</a> </li>
</ul><h2> Extras </h2>
<ul>
<li> Componente para obter informações políticas sobre uma entidade governamental. <a href="https://github.com/govmeeting/govmeeting/issues/74">Edição 74</a> </li>
<li> Reescreva o código de autenticação do front-end em Angular. <a href="https://github.com/govmeeting/govmeeting/issues/73">Edição 73</a> </li>
<li> Recurso para obter ajuda na revisão. <a href="https://github.com/govmeeting/govmeeting/issues/69">Edição
# 69</a> </li>
<li> Crie um servidor WebApi para veicular arquivos de vídeo. <a href="https://github.com/govmeeting/govmeeting/issues/61">Edição 61</a> </li>
<li> Implementar um meio para a rede várias instâncias do Govmeeting sistemas de <a href="https://github.com/govmeeting/govmeeting/issues/">edição #</a> </li>
</ul><h1> Sistemas de Produção </h1><h2> Executando um site Govmeeting </h2>
<p> Qualquer um pode baixar o software Govmeeting e executá-lo em seus próprios servidores ou hosts compartilhados. Isto pode ser: </p>

<ul>
<li> Um órgão do próprio governo </li>
<li> Um grupo ativista cidadão </li>
<li> Um cidadão individual </li>
</ul>
<p> A escala e os requisitos da instalação dependerão do tamanho da comunidade que ela gerencia. Isso determina a carga de potentail no sistema. </p>

<p> Os requisitos também dependem da quantidade de dados que serão salvos. Uma opção é salvar apenas as transripts processadas e os dados extraídos. Suponha um tamanho de transcrição de 20.000 palavras e tamanho médio de 6 caracteres. Um ano inteiro de reuniões mensais do conselho da cidade pode caber em 1,5 meg de armazenamento. Esta é uma quantidade trivial de dados </p>

<p> No entanto, salvar e hospedar o vídeo / áudio das reuniões é outra questão. Isso seria necessário para permitir a reprodução de seções selecionadas da reunião. Os dados da transcrição armazenados contêm o horário de início / término dos comentários de todos os palestrantes. Portanto, esse é um recurso factível e talvez seja muito útil. </p>
<h2> Govmeeting.org </h2>
<p> Seria útil se um site público estivesse disponível para aqueles que não desejam instalar e manter seu próprio sistema. Isso também significa que os dados coletados não estarão sob seu controle total. Portanto, há uma troca a ser feita. </p>

<p> "govmeeting.org" é o site de demonstração atual do software. Agora, ele é executado em um host compartilhado de baixo custo. Podemos criar uma organização sem fins lucrativos que será proprietária e operará este site. Se muitos municípios optarem por usar este site, ele precisará ser executado em um serviço de nuvem como AWS ou Azure, para aumentar dinamicamente a capacidade. </p>
