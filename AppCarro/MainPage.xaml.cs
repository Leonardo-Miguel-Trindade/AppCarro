namespace AppCarro
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        //função que chama o método OnCalcularClicked quando o botão é clicado
        private void OnCalcularClicked(object? sender, EventArgs e)
        {
            //Conversão dos valores inseridos pelo usuário para double, e atrubuição de preenchimento estão preenchidos true = preenchido, false = não preenchido
            bool precoAlcoolTry = double.TryParse(EntryPrecoAlcool.Text, out double precoAlcool);
            bool precoGasolinaTry = double.TryParse(EntryPrecoGasolina.Text, out double precoGasolina);
            bool quilometragemInicialTry = double.TryParse(EntryQuilometragemInicial.Text, out double quilometragemInicial);
            bool quilometragemFinalTry = double.TryParse(EntryQuilometragemFinal.Text, out double quilometragemFinal);
            bool litrosAbastecidosTry = double.TryParse(EntryLitrosAbastecidos.Text, out double litrosAbastecidos);

            //Verificação se todos os campos foram preenchidos
            if (!precoAlcoolTry || !precoGasolinaTry || !quilometragemInicialTry || !quilometragemFinalTry || !litrosAbastecidosTry)
            {
                DisplayAlert("Erro", "Por favor, insira valores válidos em todos os campos.", "OK");

            }
            //Verificação se os valores estiverem == 0
            else if (precoAlcool == 0 || precoGasolina ==0 || quilometragemFinal == 0)
            {
                DisplayAlert("Erro", "Por favor, insira valores válidos em todos os campos", "OK");
            }
            //Verificação se a quilometragem final é menor que a inicial (Se não quebraria toda a lógica do sistema)
            else if (quilometragemFinal < quilometragemInicial)
            {
                DisplayAlert("Erro", "A quilometragem final não pode ser menor que a inicial.", "OK");

            }
            //Verificação se a quilometragem final é igual a inicial (Se não quebraria toda a lógica do sistema também)
            else if (quilometragemFinal == quilometragemInicial)
            {
                DisplayAlert("Erro", "A quilometragem final não pode ser igual à inicial.", "OK");
            }
            //Verificação se a quantidade de litros abastecidos é menor ou igual a 0 (Sem ele não tem como fazer os cálculos principais)
            else if (litrosAbastecidos <= 0)
            {
                DisplayAlert("Erro", "A quantidade de litros abastecidos deve ser um valor positivo.", "OK");
            }
            //Após todas as verificações, o sistema realiza os cálculos de consumo e custo por km, e exibe os resultados na tela
            else
            {

                //Cálculo da distância percorrida
                double distanciapercorrida = quilometragemFinal - quilometragemInicial;

                //Cálculo da regra dos 70%
                double regrados70 = precoAlcool / precoGasolina;

                //Declaração das variáveis de consumo e custo
                double consumoMedio = distanciapercorrida/litrosAbastecidos;
                double custoAlcool;
                double custoGasolina;

           
                //Consumo e custo por km do álcool e gasolina
                custoAlcool = precoAlcool / consumoMedio;
                custoGasolina = precoGasolina / consumoMedio;

                //Exibição dos resultados na tela
                LabelResultadoConsumo.Text = "Consumo: " + consumoMedio.ToString("F2") + " km/l";
                LabelResultadoCustoAlcool.Text = "Custo Alcool: " + custoAlcool.ToString("F2") + " R$/km";
                LabelResultadoCustoGasolina.Text = "Custo Gasolina: " + custoGasolina.ToString("F2") + " R$/km";
               
                
                //Verificação de qual combustível é mais custobenefício
                if (custoAlcool <= custoGasolina)
                {
                    LabelResultadoCombustivel.Text = "É mais Custobenefício abastecer com Álcool.";
                }
                else
                {
                    LabelResultadoCombustivel.Text = "É mais Custobenefício abastecer com Gasolina.";
                }

                //Verificação de qual combustível é mais custobenefício pela regra dos 70%
                if (regrados70 <= 0.7)
                {
                    LabelResultadoRegrados70.Text = "Pela regra dos 70% é mais Custo benefício abastecer com Álcool.";
                }
                else
                {
                    LabelResultadoRegrados70.Text = "Pela regra dos 70% é mais Custo benefício abastecer com Gasolina.";
                }
                Buttonlimpar.IsVisible = true;
            }
        }

        private void OnCalcularLimpar(object sender, EventArgs e)
        {
            EntryPrecoAlcool.Text = "";
            EntryPrecoGasolina.Text = "";
            EntryPrecoAlcool.Text = "";
            EntryPrecoGasolina.Text = "";
            EntryQuilometragemInicial.Text = "";
            EntryQuilometragemFinal.Text = "";
            EntryLitrosAbastecidos.Text = "";
            Buttonlimpar.IsVisible = false;
            LabelResultadoCombustivel.Text = "";
            LabelResultadoConsumo.Text = "";
            LabelResultadoCustoAlcool.Text = "";
            LabelResultadoCustoGasolina.Text = "";
            LabelResultadoRegrados70.Text = "";

        }
    }
}