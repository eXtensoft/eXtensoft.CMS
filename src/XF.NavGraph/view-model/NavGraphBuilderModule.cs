using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using XF.Core.Data;
using XF.Core.Site;
using System.Text.Json;
using System.Text.Json.Serialization;
using eXtensoft.NavGraph.ViewModels;
using System.Collections.ObjectModel;

namespace eXtensoft.NavGraph
{
    public class NavGraphBuilderModule : Module
    {

        public ObservableCollection<VertexViewModel> Items { get; set; } = new ObservableCollection<VertexViewModel>();

        public NavGraph<Node,Link> NavGraph { get; set; }

        private ICommand _ParseCommand;
        public ICommand ParseCommand
        {
            get
            {
                if (_ParseCommand == null)
                {
                    _ParseCommand = new RelayCommand(param => Parse());
                }
                return _ParseCommand;
            }
        }

        private ICommand _SaveCommand;
        public ICommand SaveCommand
        {
            get
            {
                if (_SaveCommand == null)
                {
                    _SaveCommand = new RelayCommand(param => Save());
                }
                return _SaveCommand;
            }
        }

        private string _Input;
        public string Input
        {
            get { return _Input; }
            set
            {
                _Input = value;
                OnPropertyChanged("Input");
            }
        }

        private string _Output;
        public string Output
        {
            get { return _Output; }
            set
            {
                _Output = value;
                OnPropertyChanged("Output");
            }
        }

        public NavGraphBuilderModule()
        {
            Input = Sites.simple_graph;
        }

        private void Parse()
        {
            if (!string.IsNullOrWhiteSpace(Input))
            {
                if(GraphBuilder<Node,Link>.TryParse(Input, 
                    out NavGraph<Node,Link> navgraph, 
                    out string message, (s)=> { return new Node(s); }))
                {
                    NavGraph = navgraph;
                    var graph = NavGraph.ToGraph<Node, Link>();
                    var options = new JsonSerializerOptions() { };
                    options.WriteIndented = true;
                    Output = JsonSerializer.Serialize<Graph>(graph, options);
                    GraphViewModel gvm = new GraphViewModel(graph);
                    Items.Add(gvm.Root);
                }
            }
        }

        private void Save()
        {

        }
    }
}
