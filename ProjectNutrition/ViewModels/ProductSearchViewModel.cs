using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectNutrition.Database;
using ProjectNutrition.Models;
using System.Collections.ObjectModel;
using System.Linq.Expressions;

namespace ProjectNutrition.ViewModels
{
    public partial class ProductSearchViewModel : ObservableObject
    {
        public enum DragState
        {
            Started,
            Ended
        }
        public class OnProductDragStateChangedEventArgs(DragState newState, Grid elementToAnimate) : EventArgs
        {
            public DragState NewState { get; } = newState;
            public Grid ElementToAnimate { get; } = elementToAnimate;
        }
        public event EventHandler<OnProductDragStateChangedEventArgs>? OnProductDragStateChanged;



        [ObservableProperty]
        private bool isEditingEnabled;

        private readonly DataContext context;

        [ObservableProperty]
        private ObservableCollection<Product> products = null!;

        public ProductSearchViewModel(DataContext context)
        {
            this.context = context;
            Products = [.. context.Products];
            SortByName();
        }


        [RelayCommand]
        private void SelectProduct(Product product) => SelectCommand?.Execute(product);

        [ObservableProperty]
        private Command? selectCommand;


        #region Searching
        public string SearchTerm
        {
            get => searchTerm;
            set
            {
                searchTerm = value;
                ApplySearchTerms();
            }
        }
        private string searchTerm = null!;
        private int charactersSinceSearching;

        private async void ApplySearchTerms()
        {
            if (string.IsNullOrWhiteSpace(SearchTerm))
                Products = [.. context.Products];

            if (--charactersSinceSearching <= 0)
            {
                Products = [.. (await Search(context.Products, SearchTerm))];
                charactersSinceSearching = 3;
                sortingState = SortingState.Unsorted;
            }
        }

        private static Task<IEnumerable<Product>> Search(IEnumerable<Product> data, string searchTerm, int maxDistance = 3) => Task.Run(() =>
        {
            searchTerm = searchTerm.ToLower();
            return data.Where(x =>
            {
                string name = x.Name.ToLower();
                return name.Contains(searchTerm) || CalculateLevenshteinDistance(name, searchTerm) <= maxDistance;
            });
        });

        private static int CalculateLevenshteinDistance(string source1, string source2)
        {
            var source1Length = source1.Length;
            var source2Length = source2.Length;

            var matrix = new int[source1Length + 1, source2Length + 1];

            // First calculation, if one entry is empty return full length
            if (source1Length == 0)
                return source2Length;

            if (source2Length == 0)
                return source1Length;

            // Initialization of matrix with row size source1Length and columns size source2Length
            for (var i = 0; i <= source1Length; matrix[i, 0] = i++) { }
            for (var j = 0; j <= source2Length; matrix[0, j] = j++) { }

            // Calculate rows and collumns distances
            for (var i = 1; i <= source1Length; i++)
            {
                for (var j = 1; j <= source2Length; j++)
                {
                    var cost = (source2[j - 1] == source1[i - 1]) ? 0 : 1;

                    matrix[i, j] = Math.Min(
                        Math.Min(matrix[i - 1, j] + 1, matrix[i, j - 1] + 1),
                        matrix[i - 1, j - 1] + cost);
                }
            }
            // return result
            return matrix[source1Length, source2Length];
        }
        #endregion

        #region Sorting
        private enum SortingState
        {
            Unsorted = 0,
            Ascending = 1,
            Descending = 2,
            ByName = 4,
            ByCalories = 8,
            ByProtein = 16
        }
        private SortingState sortingState;
        private bool isSorting;

        [RelayCommand]
        private void SortByName()
        {
            if (isSorting)
                return;

            isSorting = true;
            if (sortingState.HasFlag(SortingState.ByName))
            {
                Sort(x => x.Name, SortingState.ByName);
            }
            else
            {
                sortingState = SortingState.Ascending;
                Sort(x => x.Name, SortingState.ByName);
            }
            isSorting = false;
        }

        [RelayCommand]
        private void SortByCalories()
        {
            if (isSorting)
                return;

            isSorting = true;
            if (sortingState.HasFlag(SortingState.ByCalories))
            {
                Sort(x => x.Calories, SortingState.ByCalories);
            }
            else
            {
                sortingState = SortingState.Ascending;
                Sort(x => x.Calories, SortingState.ByCalories);
            }
            isSorting = false;
        }

        [RelayCommand]
        private void SortByProtein()
        {
            if (isSorting)
                return;

            isSorting = true;
            if (sortingState.HasFlag(SortingState.ByProtein))
            {
                Sort(x => x.Proteins, SortingState.ByProtein);
            }
            else
            {
                sortingState = SortingState.Ascending;
                Sort(x => x.Proteins, SortingState.ByProtein);
            }
            isSorting = false;
        }

        private void Sort<T>(Expression<Func<Product, T>> sortingExpression, SortingState defaultState)
        {
            if (sortingState.HasFlag(SortingState.Ascending))
            {
                Products = [.. Products.AsQueryable().OrderBy(sortingExpression)];
                sortingState = defaultState | SortingState.Descending;
            }
            else if (sortingState.HasFlag(SortingState.Descending))
            {
                Products = [.. Products.AsQueryable().OrderByDescending(sortingExpression)];
                sortingState = defaultState | SortingState.Ascending;
            }
        }
        #endregion

        #region Deletion
        private Product? productToDelete;

        [RelayCommand]
        private void StartProductDrag(Element element)
        {
            if (element is not DragGestureRecognizer dragGR || dragGR.Parent is not Grid grid || grid.BindingContext is not Product productToDelete)
                return;

            OnProductDragStateChanged?.Invoke(this, new(DragState.Started, grid));
            this.productToDelete = productToDelete;
        }

        [RelayCommand]
        private void ConfirmProductDeletion()
        {
            if (productToDelete is null)
                return;

            Products.Remove(productToDelete);

            context.Products.Delete(productToDelete);
            context.SaveChanges();

            productToDelete = null;
        }

        [RelayCommand]
        private void DropProduct(Element element)
        {
            if (element is not DragGestureRecognizer dragGR || dragGR.Parent is not Grid grid || grid.BindingContext is not Product)
                return;

            OnProductDragStateChanged?.Invoke(this, new(DragState.Ended, grid));
            productToDelete = null;
        }
        #endregion
    }
}
