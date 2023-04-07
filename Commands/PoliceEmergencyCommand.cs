namespace EmergencyServices
{
    class PoliceCommand : ICommand
{
    private EmergencyService _emergencyService;
    
    public PoliceCommand(EmergencyService emergencyService)
    {
        _emergencyService = emergencyService;
    }
    
    public void Execute()
    {
        _emergencyService.SendMessage();
    }
}
}