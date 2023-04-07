namespace EmergencyServices
{
    class AmbulanceCommand : ICommand
{
    private EmergencyService _emergencyService;
    
    public AmbulanceCommand(EmergencyService emergencyService)
    {
        _emergencyService = emergencyService;
    }
    
    public void Execute()
    {
        _emergencyService.SendMessage();
    }
}
}