using MehmetEgitKurumsal.BLL.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehmetEgitKurumsal.BLL.Repository.Service
{
   public class EntityService
    {
        public EntityService()
        {
            _userService = new UserRepository();
            _blogService = new BlogRepository();
            _blogCommentService = new BlogCommentRepository();
            _galeryService = new GaleryRepository();
            _generalSettingService = new GeneralSettingsRepository();
            _menuService = new MenuRepository();
            _packetService = new PacketRepository();
            _pageService = new PageRepository();
            _purchaseService = new PurchaseRepository();
            _sliderService = new SliderRepository();
            _videoService = new VideoRepository();
            _announcementService = new AnnouncementRepository();
            _blogCategoryService = new BlogCategoryRepository();
            _contactMainService = new ContactMainRepository();
            _videoEducationTeacherService = new VideoEducationTeacherRepository();
            _contactService = new ContactRepository();
        }


        private ContactRepository _contactService;
        public ContactRepository ContactService
        {
            get { return _contactService; }
            set { _contactService = value; }
        }


        private VideoEducationTeacherRepository _videoEducationTeacherService;
        public VideoEducationTeacherRepository VideoEducationTeacherService
        {
            get { return _videoEducationTeacherService; }
            set { _videoEducationTeacherService = value; }
        }


        private ContactMainRepository _contactMainService;
        public ContactMainRepository ContactMainService
        {
            get { return _contactMainService; }
            set { _contactMainService = value; }
        }



        private BlogCategoryRepository _blogCategoryService;
        public BlogCategoryRepository BlogCategoryService
        {
            get { return _blogCategoryService; }
            set { _blogCategoryService = value; }
        }



        private AnnouncementRepository _announcementService;
        public AnnouncementRepository AnnouncementService
        {
            get { return _announcementService; }
            set { _announcementService = value; }
        }


        private VideoRepository _videoService;
        public VideoRepository VideoService
        {
            get { return _videoService; }
            set { _videoService = value; }
        }

        private SliderRepository _sliderService;
        public SliderRepository SliderService
        {
            get { return _sliderService; }
            set { _sliderService = value; }
        }


        private PurchaseRepository _purchaseService;
        public PurchaseRepository PurchaseService
        {
            get { return _purchaseService; }
            set { _purchaseService = value; }
        }

        private PageRepository _pageService;
        public PageRepository PageService
        {
            get { return _pageService; }
            set { _pageService = value; }
        }

        private PacketRepository _packetService;

        public PacketRepository PacketService
        {
            get { return _packetService; }
            set { _packetService = value; }
        }



        private MenuRepository _menuService;

        public MenuRepository MenuService
        {
            get { return _menuService; }
            set { _menuService = value; }
        }


        private GeneralSettingsRepository _generalSettingService;

        public GeneralSettingsRepository GeneralSettingsService
        {
            get { return _generalSettingService; }
            set { _generalSettingService = value; }
        }


        private GaleryRepository _galeryService;

        public GaleryRepository GaleryService
        {
            get { return _galeryService; }
            set { _galeryService = value; }
        }


        private BlogCommentRepository _blogCommentService;

        public BlogCommentRepository BlogCommentService
        {
            get { return _blogCommentService; }
            set { _blogCommentService = value; }
        }



        private UserRepository _userService;

        public UserRepository UserService
        {
            get { return _userService; }
            set { _userService = value; }
        }


        private BlogRepository _blogService;

        public BlogRepository BlogService
        {
            get { return _blogService; }
            set { _blogService = value; }
        }






    }
}
