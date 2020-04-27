namespace QuantumRandomNumberGenerator
{
    open Microsoft.Quantum.Intrinsic;

    operation RandomNumberGenerator() : Result
    {
        using (qubit = Qubit())
        {      
            // Colocando o qubit em sobreposição, agora ele possui 50% de chance de ser 0 ou 1.
            H(qubit);
            // Medindo e armazenando o valor do qubit, podendo ser 0 ou 1.
            let measured = M(qubit);
            // Resetando explicitamente o valor do qubit para 0.
            Reset(qubit);
            // Retornando o valor obtido através da observação do qubit.
            return measured;
        }
    }    
}