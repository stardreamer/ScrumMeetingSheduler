using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ScrumMeetingSheduler.Models;

namespace ScrumMeetingSheduler.Controllers
{
    [Route("api/[controller]")]
    public class UsersController
    {
        static List<User>  _users = new List<User>()
        {
            new User{Id = 1, Name = "ViridRaven"},
            new User{Id = 2, Name = "uncle"},
            new User{Id = 3, Name = "ftvkun"},

        };

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _users;
        }

        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody]ICollection<User> users)
        {
            _users.AddRange(users);

            var a = JsonConvert.SerializeObject(
                new
                {
                    success = true,
                    message = "Users were changed"
                }
            );
            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(
                    JsonConvert.SerializeObject(
                        new
                        {
                            success = true,
                            message = "Users were changed"
                        }
                    ))
            };
        }

        [HttpPut("{id}")]
        public HttpResponseMessage Put(int id, [FromBody]User user)
        {
            var uid = _users.FindIndex(u => u.Id == id);

            if (uid == -1)
            {
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Content = new StringContent(
                        JsonConvert.SerializeObject(
                            new
                            {
                                success = false,
                                message = "User was not found"
                            }
                    ))
                };
            }

            _users[uid] = user;

            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(
                        JsonConvert.SerializeObject(
                            new
                            {
                                success = true,
                                message = "User was changed"
                            }
                    ))
            };
        }

        [HttpDelete("{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var uid = _users.FindIndex(u => u.Id == id);

            if (uid == -1)
            {
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Content = new StringContent(
                        JsonConvert.SerializeObject(
                            new
                            {
                                success = false,
                                message = "User was not found"
                            }
                    ))
                };
            }

            _users.Remove(_users[uid]);

            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(
                        JsonConvert.SerializeObject(
                            new
                            {
                                success = true,
                                message = "User was deleted"
                            }
                    ))
            };
        }
    }
}
