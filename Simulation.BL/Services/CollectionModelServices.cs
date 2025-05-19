using Simulation.BL.ViewModels;
using Simulation.DAL.Contexts;
using Simulation.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.BL.Services
{
    public class CollectionModelServices
    {
        private readonly AppDbContext _context;
        public CollectionModelServices()
        {
            _context = new AppDbContext();
        }
        public void Create(CollectionModelVM collectionModelVM)
        {
            CollectionModel collection = new CollectionModel();
            //mapping
            collection.Name = collectionModelVM.Name;
            collection.Category = collectionModelVM.Category;
            collection.ItemsInCollection = collectionModelVM.ItemsInCollection;
            //File upload 
            string fileName = Path.GetFileNameWithoutExtension(collectionModelVM.Image.FileName);
            string extension = Path.GetExtension(collectionModelVM.Image.FileName);
            string fullName = fileName + Guid.NewGuid().ToString() + extension;
            collection.ImgPath = fullName;
            //File Upload Olacaqi Yer
            string uploadPath = @"C:\Users\Abu\OneDrive\Desktop\NEW-NFT-main\Simulation.MVC\wwwroot\assets\UploadedImages";
            uploadPath = Path.Combine(uploadPath, fullName);
            using FileStream stream = new FileStream(uploadPath, FileMode.Create);
            collectionModelVM.Image.CopyTo(stream);
            _context.Add(collection);
            _context.SaveChanges();
        }
        #region Read
        public CollectionModel GetCollectionById(int? Id)
        {
            if (Id is null)
            {
                throw new Exception();
            }
            CollectionModel collection = _context.CollectionModels.Find(Id);
            return collection;

        }
        #endregion 
        public List<CollectionModel> GetAllCollections()
        {
            List<CollectionModel> list = _context.CollectionModels.ToList();
            return list;
        }
        public void Update(int Id,CollectionModelUpdateVM collectionModelUpdateVM)
        {
            CollectionModel collection = GetCollectionById(Id);
            collection.Name = collectionModelUpdateVM.Name;
            collection.Category = collectionModelUpdateVM.Category;
            collection.ItemsInCollection = collectionModelUpdateVM.ItemsInCollection;

            if(collectionModelUpdateVM.Image is not null)
            {
                string fileName = Path.GetFileNameWithoutExtension(collectionModelUpdateVM.Image.FileName);
                string extension = Path.GetExtension(collectionModelUpdateVM.Image.FileName);
                string fullName = fileName + Guid.NewGuid().ToString() + extension;
                collection.ImgPath = fullName;
                //File Upload Olacaqi Yer
                string uploadPath = @"C:\Users\II Novbe\Desktop\Simulation-NFT-main\Simulation.MVC\wwwroot\assets\UploadedImages";
                uploadPath = Path.Combine(uploadPath, fullName);
                using FileStream stream = new FileStream(uploadPath, FileMode.Create);
                collectionModelUpdateVM.Image.CopyTo(stream);
                _context.Add(collection);
                _context.SaveChanges();
            }


        }

        public void Delete(int Id)
        {
            CollectionModel collection = GetCollectionById(Id);
            _context.Remove(collection);
            _context.SaveChanges();
        }

   

    }
}
