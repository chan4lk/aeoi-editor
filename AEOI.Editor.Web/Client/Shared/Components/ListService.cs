namespace AEOI.Editor.Web.Client.Shared.Components
{
    // the following static class mimics an actual data service that handles the actual data source
    // replace it with your actual service through the DI, this only mimics how the API can look like and works for this standalone page
    public static class ListService
    {
        private static List<Employee> _data { get; set; } = new List<Employee>();
        private static List<string> _teams = new List<string> { "Sales", "Dev", "Support" };

        public static async Task Create(Employee itemToInsert)
        {
            itemToInsert.Id = _data.Count + 1;
            _data.Insert(0, itemToInsert);
        }

        public static async Task<List<Employee>> Read()
        {
            if (_data.Count < 1)
            {
                for (int i = 1; i < 50; i++)
                {
                    _data.Add(new Employee()
                    {
                        Id = i,
                        Name = $"Name {i}",
                        Team = _teams[i % _teams.Count]
                    });
                }
            }

            return await Task.FromResult(_data);
        }

        public static async Task<List<string>> GetTeams()
        {
            return await Task.FromResult(_teams);
        }

        public static async Task Update(Employee itemToUpdate)
        {
            var index = _data.FindIndex(i => i.Id == itemToUpdate.Id);
            if (index != -1)
            {
                _data[index] = itemToUpdate;
            }
        }

        public static async Task Delete(Employee itemToDelete)
        {
            _data.Remove(itemToDelete);
        }
    }
}
