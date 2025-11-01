$(document).ready(function() {
    // Game variables
    let gameBoard = [];
    let selectedCards = [];
    let matchedPairs = 0;
    let totalPairs = 8;
    let gameStarted = false;
    let startTime;
    let timerInterval;
    
    // Animal emojis for the game
    const animalEmojis = [
        '🐺', // wolf
        '🦁', // lion
        '🐮', // cow
        '🦊', // fox
        '🐱', // cat
        '🐷', // pig
        '🐯', // tiger
        '🐶'  // dog
    ];
    
    // Initialize the game
    function initGame() {
        resetGame();
        createGameBoard();
        shuffleCards();
        renderBoard();
    }
    
    // Reset game state
    function resetGame() {
        gameBoard = [];
        selectedCards = [];
        matchedPairs = 0;
        gameStarted = false;
        updateMatchCounter();
        resetTimer();
        clearInterval(timerInterval);
        $('.game-won').remove();
    }
    
    // Create the game board with pairs of emojis
    function createGameBoard() {
        // Create pairs of emojis
        for (let i = 0; i < totalPairs; i++) {
            gameBoard.push({
                id: i * 2,
                emoji: animalEmojis[i],
                matched: false
            });
            gameBoard.push({
                id: i * 2 + 1,
                emoji: animalEmojis[i],
                matched: false
            });
        }
    }
    
    // Shuffle the cards using Fisher-Yates algorithm
    function shuffleCards() {
        for (let i = gameBoard.length - 1; i > 0; i--) {
            const j = Math.floor(Math.random() * (i + 1));
            [gameBoard[i], gameBoard[j]] = [gameBoard[j], gameBoard[i]];
        }
    }
    
    // Render the game board
    function renderBoard() {
        const $gameBoard = $('#gameBoard');
        $gameBoard.empty();
        
        gameBoard.forEach((card, index) => {
            const $card = $('<div>')
                .addClass('game-card')
                .attr('data-index', index)
                .attr('data-emoji', card.emoji)
                .text(card.emoji);
            
            if (card.matched) {
                $card.addClass('matched');
            }
            
            $gameBoard.append($card);
        });
    }
    
    // Handle card click
    $(document).on('click', '.game-card', function() {
        if (!gameStarted) {
            startGame();
        }
        
        const $card = $(this);
        const index = parseInt($card.attr('data-index'));
        const card = gameBoard[index];
        
        // Prevent clicking on already matched or selected cards
        if (card.matched || selectedCards.length >= 2 || selectedCards.includes(index)) {
            return;
        }
        
        // Add card to selected cards
        selectedCards.push(index);
        $card.addClass('selected');
        
        // Check for match when two cards are selected
        if (selectedCards.length === 2) {
            setTimeout(checkMatch, 1000);
        }
    });
    
    // Check if selected cards match
    function checkMatch() {
        const [firstIndex, secondIndex] = selectedCards;
        const firstCard = gameBoard[firstIndex];
        const secondCard = gameBoard[secondIndex];
        
        if (firstCard.emoji === secondCard.emoji) {
            // Match found
            firstCard.matched = true;
            secondCard.matched = true;
            matchedPairs++;
            
            $(`.game-card[data-index="${firstIndex}"]`).removeClass('selected').addClass('matched');
            $(`.game-card[data-index="${secondIndex}"]`).removeClass('selected').addClass('matched');
            
            updateMatchCounter();
            
            // Check if game is won
            if (matchedPairs === totalPairs) {
                gameWon();
            }
        } else {
            // No match
            $(`.game-card[data-index="${firstIndex}"]`).removeClass('selected').addClass('wrong');
            $(`.game-card[data-index="${secondIndex}"]`).removeClass('selected').addClass('wrong');
            
            setTimeout(() => {
                $(`.game-card[data-index="${firstIndex}"]`).removeClass('wrong');
                $(`.game-card[data-index="${secondIndex}"]`).removeClass('wrong');
            }, 500);
        }
        
        selectedCards = [];
    }
    
    // Start the game timer
    function startGame() {
        gameStarted = true;
        startTime = Date.now();
        timerInterval = setInterval(updateTimer, 10); // Update every 10ms for milliseconds
    }
    
    // Update timer display
    function updateTimer() {
        const elapsed = Date.now() - startTime;
        const minutes = Math.floor(elapsed / 60000);
        const seconds = Math.floor((elapsed % 60000) / 1000);
        const milliseconds = elapsed % 1000;
        
        const formattedTime = 
            `${minutes.toString().padStart(2, '0')}:` +
            `${seconds.toString().padStart(2, '0')}:` +
            `${milliseconds.toString().padStart(3, '0')}`;
        
        $('.timer-display').text(formattedTime);
    }
    
    // Reset timer
    function resetTimer() {
        $('.timer-display').text('00:00:000');
    }
    
    // Update match counter
    function updateMatchCounter() {
        $('.matches-counter').text(`Matches found : ${matchedPairs}`);
    }
    
    // Game won
    function gameWon() {
        clearInterval(timerInterval);
        const finalTime = $('.timer-display').text();
        
        const $winMessage = $('<div>')
            .addClass('game-won')
            .html(`🎉 Congratulations! 🎉<br>You won in ${finalTime}!`);
        
        $('.game-header').after($winMessage);
        
        // Add celebration effect
        setTimeout(() => {
            $winMessage.fadeOut(500);
        }, 3000);
    }
    
    // Randomize emojis for new game
    function randomizeEmojis() {
        // Shuffle the animalEmojis array
        for (let i = animalEmojis.length - 1; i > 0; i--) {
            const j = Math.floor(Math.random() * (i + 1));
            [animalEmojis[i], animalEmojis[j]] = [animalEmojis[j], animalEmojis[i]];
        }
    }
    
    // Event handlers
    $('#newGameBtn').click(function() {
        randomizeEmojis(); // Randomize emojis for new game
        initGame();
    });
    
    $('#resetBtn').click(function() {
        initGame();
    });
    
    // Initialize the game on page load
    initGame();
});