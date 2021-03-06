﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Web.Http;
using FestivalApp.API.DTO;
using FestivalApp.Services;

namespace UserApp.API.Controllers
{
    [RoutePrefix("api")]
    public class UserController : ApiController
    {
        private UserService userService;

        public UserController()
        {
            userService = new UserService();
        }

        [HttpGet]
        [Route("users")]
        public IHttpActionResult GetAll()
        {
            var users = userService.GetAll();
            var usersDTO = Mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(users);
            return Ok(usersDTO);
        }

        [HttpGet]
        [Route("users/{id:int}")]
        public IHttpActionResult Get(int id)
        {
            var user = userService.Get(id);
            if (user == null)
                return NotFound();

            var userDTO = Mapper.Map<User, UserDTO>(user);
            return Ok(userDTO);
        }

        [HttpGet]
        [Route("users/username")]
        public IHttpActionResult GetByUsername(string username)
        {
            var user = userService.GetByUsername(username);
            if (user == null)
                return NotFound();

            var userDTO = Mapper.Map<User, UserDTO>(user);
            return Ok(userDTO);
        }

        [HttpPost]
        [Route("users")]
        public IHttpActionResult Create(UserDTO userDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = userService.GetByUsername(userDTO.Username);
                    if(user != null)
                    {
                        return BadRequest("Username already exists.");
                    }

                    user = Mapper.Map<UserDTO, User>(userDTO);
                    userService.Create(user);
                    return Ok("User succesfully created");
                }
                catch (Exception ex)
                {
                    return BadRequest("Something went wrong.");
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        [Route("users/change-password")]
        public IHttpActionResult ChangePassword(ChangePasswordDTO changePasswordDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = userService.GetByUsername(changePasswordDTO.Username);
                    if (user == null)
                        return NotFound();

                    if (user.Password != changePasswordDTO.OldPassword)
                        return BadRequest("Wrong old password.");

                    userService.ChangePassword(changePasswordDTO.Username, changePasswordDTO.NewPassword);

                    return Ok("Password successfully changed.");
                }
                catch (Exception ex)
                {
                    return BadRequest("Something went wrong.");
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        [Route("users")]
        public IHttpActionResult Update(UserUpdateDTO userDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = userService.GetByUsername(userDTO.Username);
                    if (user == null)
                        return NotFound();

                    user.Firstname = userDTO.Firstname;
                    user.Lastname = userDTO.Lastname;
                    user.Age = userDTO.Age;
                    user.City = userDTO.City;
                    user.Country = userDTO.Country;
                    user.Address = userDTO.Address;
                    user.AboutMe = userDTO.AboutMe;

                    userService.Update(user);

                    return Ok("User succesfully updated.");
                }
                catch (Exception ex)
                {
                    return BadRequest("Something went wrong.");
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("users")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var user = userService.Get(id);
                if (user == null)
                    return NotFound();

                userService.Delete(id);
                return Ok("User type succesfully deleted.");
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong.");
            }
        }

        [HttpGet]
        [Route("users/login")]
        public IHttpActionResult Login(string username, string password)
        {
            try
            {
                var userExists = userService.Login(username, password);
                
                return Ok(userExists);
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong.");
            }
        }
    }
}
