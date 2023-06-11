using Microsoft.AspNetCore.Mvc;
using APINETALL.Utils;
using APINETALL.JWT;
using APINETALL.Structs;
using APINETALL.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Net;
using Microsoft.AspNetCore.Authorization;

namespace APINETALL.Controllers
{
    public class UsuarioController : Controller
    {
        /// <summary>
        /// Enviar usuario y contraseña
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns>Regresará una estructura Message, Success; si Success=true el token de acceso se encontrará en el Message</returns>
        [HttpPost("/GetToken")]
        [ProducesResponseType(typeof(BasicResponse), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> ObtenerToken(string user, string password)
        {
            try
            {
                var basicResponse = new BasicResponse();
                var response = basicResponse;
                var usuario = new UsuarioRepository().ObtenerUsuario(user, password);
                if (usuario != null)
                {
                    var jwt = new JwtManager();
                    var token = jwt.GenerateJwtToken(user);
                    var validate = jwt.ValidateJwtToken(token);
                    response.Success = true;
                    response.Message = token;
                    return Ok(response);
                }
                else
                {
                    response.Success = false;
                    response.Message = "Usuario y/o contraseña incorrectos";
                    return BadRequest(response);
                }

            }
            catch (Exception ex)
            {

                BadRequest(new BasicResponse { Message = "Error al procesar su solicitud " + ex, Success = false });
                throw;
            }
        }

        /// <summary>
        /// Enviar token para validar funcionamiento de Autenticación
        /// </summary>
        /// <returns></returns>
        [HttpPost("/ValidarToken")]
        [ProducesResponseType(typeof(BasicResponse), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ValidarToken()
        {
            try
            {
                var basicResponse = new BasicResponse{Message ="OK", Success =true};
                return Ok(basicResponse);                

            }
            catch (Exception ex)
            {

                BadRequest(new BasicResponse { Message = "Error al procesar su solicitud " + ex, Success = false });
                throw;
            }
        }
    }
}