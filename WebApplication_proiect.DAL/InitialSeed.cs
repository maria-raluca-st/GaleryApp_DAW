﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication_proiect.DAL.Entities;

namespace WebApplication_proiect.DAL
{
    public class InitialSeed
    {
        private readonly RoleManager<Role> _roleManager;

        public InitialSeed(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }

        public async void CreateRoles()
        {
            string[] roleNames = {
                                "Admin",
                                "Photographer"
                                };

            foreach (var roleName in roleNames)
            {
                var role = new Role
                {
                    Name = roleName
                };
                _roleManager.CreateAsync(role).Wait();
            }
        }
    }
}
