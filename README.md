# Adita.PlexNet.Wpf.Dialogs

A WPF dialog for PlexNet framework that targeting .NET 6 which is the implementation of <c>Adita.PlexNet.Wpf.Dialogs<c/>.

This library is designed to work with <c>Microsoft.Extensions.DependencyInjection<c/>.

## How To Use

1. Create dialog model that inherits one of the following class:

	<li>
		<ul><c>Adita.PlexNet.Wpf.Dialogs.Dialog</c></ul>
			Use this if the dialog don't need any parameter and not return value.
		<ul><c>Adita.PlexNet.Wpf.Dialogs.Dialog<TReturn></c></ul>
			Use this if the dialog don't need any parameter but return value.
		<ul><c>Adita.PlexNet.Wpf.Dialogs.IDialog<TReturn, TParam></c></ul>
			Use this if the dialog need a parameter and return value.
	</li>

2. Register the models to service container

    Services.AddDialogs(dialogBuilder =>
            {
                dialogBuilder.RegisterDialog<DialogSample>()
                .RegisterDialog<DialogWithReturnSample>()
                .RegisterDialog<DialogWithReturnAndParamSample>();
            });
    

3. Add <c>Adita.PlexNet.Wpf.DialogHost</c> to any object on a window that want to show the dialog.

    Example:
	 <dg:DialogHost.DialogViews>
        <dg:DialogViewCollection>
            <dg:DialogViewDescriptor>
                <dg:DialogViewDescriptor.ViewTemplate>
                    <DataTemplate DataType="{x:Type viewModels:DialogSample}">
                        <Border Padding="10">
                            <StackPanel>
                                <TextBlock HorizontalAlignment="Center"
                                       VerticalAlignment="Center"
                                       Text="{Binding Data}"/>
                                <Button Padding="20,5,20,0" Margin="0,10,0,0" HorizontalAlignment="Right"
                                    Command="{Binding OkCommand}">OK</Button>
                            </StackPanel>
                        </Border>
                    </DataTemplate>
                </dg:DialogViewDescriptor.ViewTemplate>
            </dg:DialogViewDescriptor>
        </dg:DialogViewCollection>
    </dg:DialogHost.DialogViews>

4. Inject <c>Adita.PlexNet.Core.IDialogService<c> to your view model that want to show the dialog
    and call following methods depend on the type of the dialog model:

    <li>
		<ul><c>Adita.PlexNet.Core.IDialogService.ShowDialog<TDialog>()</c></ul>
			To call a dialog with no return and no parameter, this will return <c>Adita.PlexNet.Core.Dialogs.DialogResult</c>.
		<ul><c>Adita.PlexNet.Core.IDialogService.ShowDialog<TDialog, TReturn>()</c></ul>
			To call a dialog with return value but no parameter, this will return <c>Adita.PlexNet.Core.Dialogs.DialogResult<TReturn, TParam></c>.
		<ul><c>Adita.PlexNet.Core.IDialogService.ShowDialog<TDialog, TReturn, TParam>()</c></ul>
			Use this if the dialog need a parameter and return value.
	</li>