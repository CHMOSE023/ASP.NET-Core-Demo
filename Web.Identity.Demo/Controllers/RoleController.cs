using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Identity.Demo.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Web.Identity.Demo.Controllers;

[Authorize]
public class RoleController : Controller
{

    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;    

    public RoleController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {

        _userManager = userManager;
        _roleManager = roleManager;
    }

    // 获取所有角色
    public async Task<IActionResult> Index()
    {
        IdentityRole role;
        var roles =await _roleManager.Roles.ToListAsync();
        return View(roles);
    }

    public IActionResult AddRole()
    {
       
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddRole(RoleAddViewModel roleAddViewModel)
    {
        if (!ModelState.IsValid)
        {

            return View(roleAddViewModel);

        }

        var role = new IdentityRole
        {
            Name = roleAddViewModel.RoleName,
        };


        var result = _roleManager.CreateAsync(role).Result;

        if (result.Succeeded)
        {
            return RedirectToAction("Index");
        }
        else
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);

            }

            return View(roleAddViewModel);
        }
        
    }
}

