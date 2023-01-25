using System.Security.Cryptography;
using System.Text;

namespace WebSis.Models
{
    // Classe responsável pelo algoritmo que irá transformar os campos de senha do usuário em Hash MD5 para uma maior segurança no armazenamento de registro dos usuários
    public class Cryptography
    {
        public static string EncryptedText(string passwordDescrypted)
        {
            MD5 MD5Hasher = MD5.Create(); // Chamada do método Create da Classe de hash MD5 que irá armazenar o valor em um objeto MD5 e criar a hash.

            byte[] descryptedByte = Encoding.Default.GetBytes(passwordDescrypted); // Recebe os bytes da string descriptografada passada como parâmetro e os armazena em um array de bytes
            byte[] encryptedByte = MD5Hasher.ComputeHash(descryptedByte); // Recebe o array de bytes descriptografados na chamada do método ComputeHash que irá computar nossa hash MD5 e armazenará o resultado em um novo array de bytes.

            StringBuilder sb = new StringBuilder(); // Instância da classe StringBuilder que irá processar nossos bytes 

            foreach (byte b in encryptedByte) // A estrutura de repetição percorre todos os bytes do nosso array computado e gera uma string (hash MD5) com o resultado de bytes processados pelo objeto de processamento de bytes
            {
                string DebugB = b.ToString("x2");
                sb.Append(DebugB);
            }

            return sb.ToString(); // retorna os valores processados em formato de string.
        }

    }
}