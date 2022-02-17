/**
 * @param {number} n
 * @return {number}
 */
var numTilings = function(n) {
    const MOD = 1e9 + 7;

    let dp = Array.from({length: n + 1}, x => [0, 0]);

    dp[0][0] = 1;
    dp[1][0] = 1;

    for (let i = 2; i <= n; i++) {
        dp[i][0] = (dp[i - 1][0] + dp[i - 2][0] + 2 * dp[i - 1][1]) % MOD;
        dp[i][1] = (2 * dp[i - 2][0] + 2 * dp[i - 1][1]) % MOD;
    }

    return dp[n][0];
};

numTilings(3);