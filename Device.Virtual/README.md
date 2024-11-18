# Device Virtual Simulator
## Descrição
O Device Virtual Simulator é uma aplicação em .NET que simula dispositivos e aplicativos interagindo com um broker MQTT. Ele permite testar comandos MQTT, observar respostas em tópicos específicos e simular o comportamento de dispositivos com diferentes números de canais.

Esta aplicação pode ser usada para validar interações MQTT, testar dispositivos virtuais e diagnosticar configurações de comunicação MQTT.

## Índice
1. [Características](#)
2. [Pré-requisitos](#)
3. [Instalação](#)
4. [Uso](#)
5. [Configuração](#)
6. [Estrutura do Projeto](#)
7. [Contribuição](#)
8. [Licença](#)
## Características
- Simula dispositivos virtuais com 1, 2 ou 3 canais.
- Publica e subscreve tópicos MQTT.
- Responde a comandos MQTT comuns, como:
  - ON e OFF: Ligar e desligar dispositivos.
  - ALLINFO: Retorna informações detalhadas sobre o dispositivo (firmware, sinal Wi-Fi, tempo de operação, etc.).
  - ResetWifi: Simula um reset de Wi-Fi.
  - Connect e Disconnect: Simula estados de conexão.
- Suporte para tópicos personalizados baseados no número de canais do dispositivo.
- Oferece um modo de simulação para dispositivos ou aplicativos.
## Pré-requisitos
Para executar este projeto, você precisa:

- .NET 5.0 ou superior instalado na sua máquina.
- Um broker MQTT ativo (por exemplo, Mosquitto) disponível em sua rede.
## Instalação
### 1. Clonar o repositório

      git clone https://github.com/seu_usuario/device-virtual-simulator.git
      cd device-virtual-simulator
### 2. Restaurar dependências
Baixe as dependências necessárias com o comando:

     dotnet restore
## Uso
### Executar a aplicação
1. Compile e execute o programa:
    ````
     dotnet run
2. Siga as instruções no console:

    - Escolha o tipo de simulação (1 para dispositivo ou 2 para aplicativo).
    - Defina o tipo de dispositivo (1, 2 ou 3 canais).
    - Informe o número de série do dispositivo.
3. O programa se conectará ao broker MQTT, inscreverá os tópicos necessários e aguardará mensagens.

## Configuração
Por padrão, a aplicação tenta conectar ao broker MQTT em localhost:1883. Para usar um broker diferente:

1. Abra o arquivo MqttClientManager e altere as configurações no método ConnectAsync:

    ````
     var options = new MqttClientOptionsBuilder()
     .WithTcpServer("<endereço-do-broker>", <porta>)
     .Build();
2. Recompile a aplicação com:
    ````
    dotnet build
## Estrutura do Projeto
- Program: Ponto de entrada principal da aplicação.
- MqttClientManager: Gerencia a conexão e desconexão do cliente MQTT.
- Device: Simula dispositivos com comportamento específico em resposta a mensagens MQTT.
- Application: Simula um aplicativo que escuta mensagens MQTT em um tópico.
- Simulator: Coordena a simulação com base nas escolhas do usuário.
- UserInput: Gerencia as entradas do usuário para configuração da simulação.
## Exemplos
### Comandos suportados
1. Dispositivo:

- Comando enviado: ON
  - Resposta: O dispositivo é ativado, e o status é publicado no tópico configurado.
- Comando enviado: ALLINFO
  - Resposta:
    ````
     DEVICE-A1033*FIRMWARE_BUILD-1WIFI-90%POWERTIME-1d:18h:27m:28sALARMS-OKNTP-0d:3h:14m:35s
2. Aplicativo:

- Escuta mensagens no tópico configurado.
- Exibe o payload recebido no console.