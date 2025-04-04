﻿using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Request {
    public class AddCategoryRequest {
        public string Name { get; set; } = string.Empty;

        public Category ToEntity() {
            return new Category {
                Name = Name
            };
        }
    }
}
