using FormValidation.Models;
using FormValidation.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormValidation.Controllers
{
    public class UserRegController : Controller
    {
        public IUserServices UserServices;
        public ICreateUser CreateUser;
        public IReadData ReadData;
        public IEditData EditData;
        public IDeleteData DeleteData;
        public UserInfoModel UserModel;

        public UserRegController(IUserServices services,ICreateUser userCreate, IReadData readUser,IEditData dataEdit, IDeleteData dataDelete,UserInfoModel user)
        {
            this.UserServices = services;
            this.CreateUser = userCreate;
            this.ReadData = readUser;
            this.EditData = dataEdit;
            this.DeleteData = dataDelete;
            this.UserModel = user;
        }
        // GET: UserReg
        public ActionResult Index()
        {
            DataTable dtblUser = new DataTable();
            dtblUser = UserServices.GetData();
            return View(dtblUser);
        }

        // GET: UserReg/Details/5
        public ActionResult Details(int id)
        {
            UserModel = ReadData.ReadUser(id);
            if (UserModel.UserId!=0)
            {   
                return View(UserModel);
            }
            else
            {
                return RedirectToAction("Error404", "UserReg");
            }
           
        }

        // GET: UserReg/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserReg/Create
        [HttpPost]
        public ActionResult Create(UserInfoModel userInfo, HttpPostedFileBase UserImage)
        {
            if(UserImage != null)
            {
                string namefile = Path.GetFileName(UserImage.FileName);
                string path = Path.Combine(Server.MapPath("~/UserImages"), namefile);
                userInfo.UserImage = UserImage.FileName;
                UserImage.SaveAs(path);
                ViewBag.ImageUrl = "~/UserImages" + namefile;
            }
            if (ModelState.IsValid)
            {
                SqlCommand cmd = CreateUser.AddUser(userInfo);
                return RedirectToAction("Index", "UserReg");
            }
            else
            {
                return View(userInfo);
            }
        }

        // GET: UserReg/Edit/5
        public ActionResult Edit(int id)
        {
            if (ModelState.IsValid)
            {
                UserModel = ReadData.ReadUser(id);
                if (UserModel.UserId != 0)
                {
                    return View(UserModel);
                }
                else
                {
                    return RedirectToAction("Error404", "UserReg");
                }
            }
            else
            {
                return View(UserModel);
            }
        }

        // POST: UserReg/Edit/5
        [HttpPost]
        public ActionResult Edit(UserInfoModel userInfo, HttpPostedFileBase UserImage)
        {
            if (UserImage != null)
            {
                string namefile = Path.GetFileName(UserImage.FileName);
                string path = Path.Combine(Server.MapPath("~/UserImages"), namefile);
                userInfo.UserImage = UserImage.FileName;
                UserImage.SaveAs(path);
                ViewBag.ImageUrl = "~/UserImages" + namefile;
            }
            if (ModelState.IsValid)
            {
                SqlCommand sqlCmd = EditData.EditUser(userInfo);
                return RedirectToAction("Index", "UserReg");
            }
            else
            {
                return View(userInfo);
            }
        }

        // GET: UserReg/Delete/5
        public ActionResult Delete(int id)
        {
            UserModel = ReadData.ReadUser(id);
            if (UserModel.UserId != 0)
            {
                return View(UserModel);
            }
            else
            {
                return RedirectToAction("Error404", "UserReg");
            }
        }

        // POST: UserReg/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, UserInfoModel userInfo)
        {
            SqlCommand cmd = DeleteData.DeleteUser(id, userInfo);
            return RedirectToAction("Index", "UserRegController"); //Correct this Route
        }

        [HandleError]
        public ActionResult Error404()
        {
            return View();
        }
    }
}
