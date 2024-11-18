# Device Virtual Simulator
## Descri��o
O Device Virtual Simulator � uma aplica��o em .NET que simula dispositivos e aplicativos interagindo com um broker MQTT. Ele permite testar comandos MQTT, observar respostas em t�picos espec�ficos e simular o comportamento de dispositivos com diferentes n�meros de canais.

Esta aplica��o pode ser usada para validar intera��es MQTT, testar dispositivos virtuais e diagnosticar configura��es de comunica��o MQTT.

## �ndice
1. [Caracter�sticas](#)
2. [Pr�-requisitos](#)
3. [Instala��o](#)
4. [Uso](#)
5. [Configura��o](#)
6. [Estrutura do Projeto](#)
7. [Contribui��o](#)
8. [Licen�a](#)
## Caracter�sticas
- Simula dispositivos virtuais com 1, 2 ou 3 canais.
- Publica e subscreve t�picos MQTT.
- Responde a comandos MQTT comuns, como:
  - ON e OFF: Ligar e desligar dispositivos.
  - ALLINFO: Retorna informa��es detalhadas sobre o dispositivo (firmware, sinal Wi-Fi, tempo de opera��o, etc.).
  - ResetWifi: Simula um reset de Wi-Fi.
  - Connect e Disconnect: Simula estados de conex�o.
- Suporte para t�picos personalizados baseados no n�mero de canais do dispositivo.
- Oferece um modo de simula��o para dispositivos ou aplicativos.
## Pr�-requisitos
Para executar este projeto, voc� precisa:

- .NET 5.0 ou superior instalado na sua m�quina.
- Um broker MQTT ativo (por exemplo, Mosquitto) dispon�vel em sua rede.
## Instala��o
### 1. Clonar o reposit�rio

      git clone https://github.com/seu_usuario/device-virtual-simulator.git
      cd device-virtual-simulator
### 2. Restaurar depend�ncias
Baixe as depend�ncias necess�rias com o comando:

     dotnet restore
## Uso
### Executar a aplica��o
1. Compile e execute o programa:
    ````
     dotnet run
2. Siga as instru��es no console:

    - Escolha o tipo de simula��o (1 para dispositivo ou 2 para aplicativo).
    - Defina o tipo de dispositivo (1, 2 ou 3 canais).
    - Informe o n�mero de s�rie do dispositivo.
3. O programa se conectar� ao broker MQTT, inscrever� os t�picos necess�rios e aguardar� mensagens.

## Configura��o
Por padr�o, a aplica��o tenta conectar ao broker MQTT em localhost:1883. Para usar um broker diferente:

1. Abra o arquivo MqttClientManager e altere as configura��es no m�todo ConnectAsync:

    ````
     var options = new MqttClientOptionsBuilder()
     .WithTcpServer("<endere�o-do-broker>", <porta>)
     .Build();
2. Recompile a aplica��o com:
    ````
    dotnet build
## Estrutura do Projeto
- Program: Ponto de entrada principal da aplica��o.
- MqttClientManager: Gerencia a conex�o e desconex�o do cliente MQTT.
- Device: Simula dispositivos com comportamento espec�fico em resposta a mensagens MQTT.
- Application: Simula um aplicativo que escuta mensagens MQTT em um t�pico.
- Simulator: Coordena a simula��o com base nas escolhas do usu�rio.
- UserInput: Gerencia as entradas do usu�rio para configura��o da simula��o.
## Exemplos
### Comandos suportados
1. Dispositivo:

- Comando enviado: ON
  - Resposta: O dispositivo � ativado, e o status � publicado no t�pico configurado.
- Comando enviado: ALLINFO
  - Resposta:
    ````
     DEVICE-A1033*FIRMWARE_BUILD-1WIFI-90%POWERTIME-1d:18h:27m:28sALARMS-OKNTP-0d:3h:14m:35s
2. Aplicativo:

- Escuta mensagens no t�pico configurado.
- Exibe o payload recebido no console.