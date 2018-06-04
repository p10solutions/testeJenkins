using System;
using Xunit;
using Template.Framework;
using Template.Framework.Api;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Amil.SisMed.API.ViewModels;

namespace Template.Teste
{
    public class TesteIntegrador
    {
        [Fact]
        public void Test1()
        {
            var json = Json();
            var param = JsonConvert.DeserializeObject<dynamic>(json);

            var retorno = IntegradorApi.RecebeRetornoDeserializado<RetornoAppServerViewModel>("http://smsismedtest.amil.com.br/wsJSON/appserverjsoninterface.exe/json/wsTotem", param, ETipoConteudoApi.Json, EMetodoApi.Post);
        }

        [Fact]
        public async Task Test2()
        {
            var json = Json();
            var param = JsonConvert.DeserializeObject<dynamic>(json);

           var x = await GatewayAPI.Post<object>("http://smsismedtest.amil.com.br/wsJSON/appserverjsoninterface.exe/json/", "wsTotem", param);
        }

        string Json()
        {
            return "{'Command': 'IniciaAtendimentoCM','Parameters': [{'Name': 'Id_Local', 'Value': 15398},{'Name': 'CM',    'Value': '081'},{'Name': 'Id_Operadora',    'Value': '326305'},{'Name': 'Hash', 'Value': '4tVQaDGrtM2w5QGPL03gIwrZscK/0RfHKzWNyvjWP/Q='},{'Name': 'Carteirinha', 'Value': '070618208'}]}";
        }
    }
}
