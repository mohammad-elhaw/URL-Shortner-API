namespace URLShortener.Infrastructure;

public class SnowflakeGenerator
{
    private readonly object _lock = new();

    private const long Epoch = 1704067200000;

    private const int MachineIdBits = 10;
    private const int SequenceBits = 12;

    private const long MaxMachineId = -1L ^ (-1L << MachineIdBits);
    private const long MaxSequence = -1L ^ (-1L << SequenceBits);

    private readonly long _machineId;
    private long _lastTimestamp = -1;
    private long _sequence = 0;

    public SnowflakeGenerator(long machineId)
    {
        if (machineId < 0 || machineId > MaxMachineId)
            throw new ArgumentException($"Machine ID must be between 0 and {MaxMachineId}");

        _machineId = machineId;
    }

    public long NextId()
    {
        lock (_lock)
        {
            var timestamp = GetTimestamp();

            if (timestamp < _lastTimestamp)
                throw new Exception("Clock moved backwards!");

            if (timestamp == _lastTimestamp)
            {
                _sequence = (_sequence + 1) & MaxSequence;

                if (_sequence == 0)
                    timestamp = WaitNextMillis(timestamp);
            }
            else
            {
                _sequence = 0;
            }

            _lastTimestamp = timestamp;

            return ((timestamp - Epoch) << (MachineIdBits + SequenceBits))
                   | (_machineId << SequenceBits)
                   | _sequence;
        }
    }

    private static long GetTimestamp() =>
        DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

    private static long WaitNextMillis(long lastTimestamp)
    {
        long timestamp;
        do
        {
            timestamp = GetTimestamp();
        } while (timestamp <= lastTimestamp);

        return timestamp;
    }
}
