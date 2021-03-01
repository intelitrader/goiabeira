﻿using Goiabinha_API_Core.Context;
using Goiabinha_API_Core.Interfaces;
using Goiabinha_API_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Goiabinha_API_Core.Repositories
{
    public class UsuarioRepository : IUsuario
    {
        public void delete(string id)
        {
            using (GoiabinhaContext Ctx = new GoiabinhaContext())
            {
                var delUser = getById(id);
                if (delUser != null)
                {
                    Ctx.Usuarios.Remove(delUser);
                    Ctx.SaveChanges();
                }
            }
        }

        public List<Usuarios> get()
        {
            using (GoiabinhaContext Ctx = new GoiabinhaContext())
            {
                return Ctx.Usuarios.ToList();
            }
        }

        public Usuarios getById(string id)
        {
            using (GoiabinhaContext Ctx = new GoiabinhaContext())
            {
                return Ctx.Usuarios.FirstOrDefault(u => u.id == id);
            }
        }

        public void post(Usuarios Usuario)
        {
            using (GoiabinhaContext Ctx = new GoiabinhaContext())
            {
                string idUser = Guid.NewGuid().ToString().Replace("-","").Remove(25);
                for (int i = 5; i <= 23; i += 6)
                    idUser = idUser.Insert(i, "-");
                Usuario.id = idUser;
                Usuario.creationDate = DateTime.Now;
                Ctx.Usuarios.Add(Usuario);
                Ctx.SaveChanges();
            }
        }

        public void update(string id, Usuarios NewUsuario)
        {
            using (GoiabinhaContext Ctx = new GoiabinhaContext())
            {
                var user = getById(id);
                if (user != null) 
                {
                    user.firstName = (NewUsuario.firstName == "" || NewUsuario.firstName == null) ? user.firstName : NewUsuario.firstName;
                    user.surname = (NewUsuario.surname == "" || NewUsuario.surname == null) ? user.surname : NewUsuario.surname;
                    user.age = (NewUsuario.age == 0) ? user.age : NewUsuario.age;

                    Ctx.Usuarios.Update(user);
                    Ctx.SaveChanges();
                }
            }
        }
    }
}