﻿using MVVMEditComboBoxItemsSample.MockModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMEditComboBoxItemsSample
{
    class MainViewModel : ViewModelBase
    {
        private ObservableCollection<Thing> things;
        private Thing selectedThing;

        private ICommand addCommand;
        private ICommand cloneCommand;
        private ICommand deleteCommand;

        public MainViewModel()
        {
            Things = new ObservableCollection<Thing>(ThingDataManager.Instance.GetThings());
            SelectedThing = Things.FirstOrDefault();
        }

        public ObservableCollection<Thing> Things
        {
            get
            {
                return things;
            }

            set
            {
                things = value;
                OnPropertyChanged(nameof(Things));
            }
        }

        public Thing SelectedThing
        {
            get
            {
                return selectedThing;
            }

            set
            {
                selectedThing = value;
                OnPropertyChanged(nameof(SelectedThing));
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(Price));
                OnPropertyChanged(nameof(Things));
            }
        }

        public string Name
        {
            get
            {
                return SelectedThing.Name;
            }

            set
            {
                SelectedThing.Name = value;
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(Things));
            }
        }

        public string Price
        {
            get
            {
                return SelectedThing.Price;
            }

            set
            {
                SelectedThing.Price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        public ICommand AddCommand
        {
            get
            {
                if(addCommand==null)
                {
                    addCommand = new CommandBase(i => AddItem(), null);
                }
                return addCommand;
            }
        }

        public ICommand CloneCommand
        {
            get
            {
                if(cloneCommand==null)
                {
                    cloneCommand = new CommandBase(i => CloneItem(), null);
                }
                return cloneCommand;
            }

        }

        public ICommand DeleteCommand
        {
            get
            {
                if(deleteCommand==null)
                {
                    deleteCommand = new CommandBase(i => DeleteItem(), null);
                }
                return deleteCommand;
            }

        }

        public void AddItem()
        {
            this.Things.Add(new Thing());
        }

        public void CloneItem()
        {
            Thing clonedThing = new Thing();
            clonedThing.Name = SelectedThing.Name;
            clonedThing.Price = SelectedThing.Price;
            this.Things.Add(clonedThing);
        }

        public void DeleteItem()
        {
            if (Things.Count < 2)
                return; //we must leave at least one thing in the inventory

            Thing tempThing = new Thing();
            tempThing = SelectedThing;
            if (Things.IndexOf(SelectedThing) != 0)
            {
                SelectedThing = Things.FirstOrDefault();
            }
            else
            {
                SelectedThing = Things[1];
            }

            Things.Remove(tempThing);
        }

    }
}